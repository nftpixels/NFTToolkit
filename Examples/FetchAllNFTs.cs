using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NFTToolkit;

public class FetchAllNFTs : MonoBehaviour
{

    // Supported Chains
    // ================
    //
    // Ethereum Mainnet = 1
    // Ethereum Sepolia = 11155111
    // Polygon Mainnet = 137
    // Polygon Mumbai = 80001
    // Arbitrum Mainnet = 42161
    // Binance Mainnet = 56
    // Binance Testnet = 97
    // Avalanche (C-Chain) = 43114
    // Palm Mainnet = 11297108109
    // Cronos Mainnet = 25
    // Fantom Mainnet = 250


    public void Start()
    {
        // To fetch all the NFTs for a wallet on a specified chain

        string chainId = "1";
        string walletToCheck = "0x28aAFd3dD531A09FE223DebaFFFCf6ddD028dF4F";

        Toolkit.AllNFTs(chainId, walletToCheck);
    }

    public void TokenGateNFT()
    {
        // After we've fecthed all the NFTs we can check against them to tokengate content
        // The format for checking a valid NFT is {ContractAddress:TokenID} - Example:
        if (OwnedNFTs.Contains("0xe19a9cc38973800189fb8b4a50cf1b66f36a66b4:24"))
        {
            Debug.Log("The player owns this token!");
        }
        else
        {
            Debug.Log("The player does not own the token.");
        }
    }
}

