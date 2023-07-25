// ----------------------------------------------------------------------------
// Script name: NFTToolkit.cs
// Author: Reinhardt Weyers
// Creation Date: July 25, 2023
// Description: A script that handles querying NFT metadata for use in blockchain games.
// ----------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class NFTToolkit : MonoBehaviour
{
    [Serialize]
    [Header("Infura Authentication")]
    [Tooltip("Infura API Key format = APIKEY:APISECRET")]
    public string APIKey;

    // Our list for storing all the queried NFTs
    public static List<string> OwnedNFTs = new List<string>();

    // Class for asset metadata
    public class Metadata
    {
        public string name;
        public string description;
        public string image;
    }

    // Class for each asset
    public class Asset
    {
        public string contract;
        public string tokenId;
        public string supply;
        public string type;
        public Metadata metadata;
    }

    // Our assets fetched from the API
    public class JsonResponse
    {
        public int total;
        public int pageNumber;
        public int pageSize;
        public string network;
        public string account;
        public string cursor;
        public List<Asset> assets;
    }

    // Singleton for access anywhere
    public static NFTToolkit Toolkit;

    // Assign our instance on awake
    public void Awake()
    {
        Toolkit = this;
    }

    public void AllNFTs(string chainId, string walletAddress)
    {
        string apiCall = "https://nft.api.infura.io/networks/" + chainId + "/accounts/" + walletAddress + "/assets/nfts";
        StartCoroutine(FetchAllNFTs(apiCall));
    }

    IEnumerator FetchAllNFTs(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            var APIAuth = "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(APIKey));

            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", APIAuth);

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);

                    // Deserialize our JSON object
                    JsonResponse jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(webRequest.downloadHandler.text);

                    foreach (Asset asset in jsonResponse.assets)
                    {
                        // Push the token and contract to it's respective list
                        // The contract address is pushed in lowercase by default
                        OwnedNFTs.Add(asset.contract.ToLower() + ":" + asset.tokenId);

                        // Push metadata to a dictionary
                        DataManager.Instance.AddMetadata(asset.metadata.name, asset.metadata);
                    }
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log(webRequest.error);

                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log(webRequest.error);

                    break;

            }
        }
    }
}
