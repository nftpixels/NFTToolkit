using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NFTToolkit;

public class ImportNFT : MonoBehaviour
{
    void Start()
    {
        // Before we can use the metadata for our tokens, we need to fetch them first

        string chainId = "1";
        string walletToCheck = "0x28aAFd3dD531A09FE223DebaFFFCf6ddD028dF4F";

        Toolkit.AllNFTs(chainId, walletToCheck);
    }


    public void GetMetaData()
    {
        // Once you've fetched all the tokens for a wallet, you can use individual data properties
        // The function allows you to get all the metadata for a token based on it's name - Example:
        Metadata metadata = DataManager.Instance.GetMetadataByName("Milkshake Friends #24");

        Debug.Log(metadata.name);
        Debug.Log(metadata.description);
        Debug.Log(metadata.image);

        // You can take this one step further and download the image by using another WebRequest and passing the metadata.image as a the URL.
    }

}
