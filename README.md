<h1 align="center">Unity NFT Toolkit</h1>

<p align="center">
  <b>Unity NFT Toolkit</b>
  <br>
  <i>Empower Your Games with NFTs: Simplified Metadata Management for Seamless Integration!</i>
</p>

<p align="center">
  <img src="https://user-images.githubusercontent.com/97366705/231331134-fb9d64c2-f3b8-404b-9cae-12124f9bbfe5.png" width=600>
  <br><br>
</p>

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)
- [Author](#author)

## Introduction

This is a comprehensive Unity toolkit designed to facilitate the handling of Non-Fungible Token (NFT) metadata within Unity applications. This project includes several scripts working in harmony to enable efficient API calls for NFT metadata retrieval and centralized storage of acquired data. With a focus on modularity and organization, this toolkit ensures seamless access to NFT metadata across different scenes and scripts, making it a valuable asset for developers working with NFT assets.

**Key features:**

- Seamlessly query all NFTs owned by a specific wallet across supported chains with just one line of code.
- Simplified metadata management enables effortless access to individual key:value pairs, ideal for token gating and unleashing your creative ideas.
- Lightweight and user-friendly design for a smooth development experience.
- Embrace the freedom to create without constraints - this toolkit is completely free to use.

Take your Unity game to the next level with the Unity NFT Toolkit.
<br>


## Installation

1. **Download the latest release from the repository.**

<br>

2. **Drag & Drop the package into your open Unity window.**

<br>

![image](https://github.com/nftpixels/NFTToolkit/assets/97366705/fd3cc5dc-9a95-4364-8470-4bd474f43977)

<br>
Make sure to import all three folders.
<br>
<br>
<br>

3. **Open the Sample Scene:**

In here you need to supply the NFTToolkit.cs script your [Infura](https://app.infura.io/dashboard) API Key:
<br>


![image](https://github.com/nftpixels/NFTToolkit/assets/97366705/47bd6476-dcd6-43a0-b06b-c385bf3bb2db)

<br>
After adding your API Key & API Secret in the format APIKEY:APISECRET - Hit the PLAY button to watch the demo scene in action!
<br>
<br>
<br>

## Usage

**Fetch All NFTs Owned By A Wallet:**
<br>
<br>
Method Structure:

```csharp
NFTToolkit.Toolkit.AllNFTs(string chainId, string walletToCheck);
```
<br>

**Unity Example:**

```csharp
    using static NFTToolkit

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
```
<br>


**Check Token Ownership:**
<br>

Query Structure:

```csharp
NFTToolkit.Toolkit.OwnedNFTs.Contains(string {ContractAddress:TokenID);
```
<br>

**Unity Example:**

```csharp
    using static NFTToolkit

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
```
<br>
<br>

**Query Token Metadata:**
<br>
<br>
Method Structure:
<br>
```csharp
Metadata token = DataManager.Instance.GetMetadataByName(string TokenName);
```
<br>

**Unity Example:**

```csharp
    using static NFTToolkit

    public void GetMetaData()
    {
        // Once you've fetched all the tokens for a wallet, you can use individual data properties
        // The function allows you to get all the metadata for a token based on it's name - Example:

        Metadata token = DataManager.Instance.GetMetadataByName("Milkshake Friends #24");

        Debug.Log(token.name);
        Debug.Log(token.description);
        Debug.Log(token.image);

        // You can take this one step further and download the image by using another WebRequest and passing the metadata.image as a the URL.
    }
```
<br>
<br>


## License
This project is licensed under the MIT License.

## Author
* Author: Reinhardt Weyers <br>
* Email: weyers70@gmail.com <br>
* GitHub: [nftpixels](https://github.com/nftpixels) <br>
* LinkedIn: https://www.linkedin.com/in/reinhardtweyers/ <br>

## Security & Liability
This repository and all of its sub-packages and connected packages are WITHOUT ANY WARRANTY; without even the implied warranty for any user commerical or otherwise. The creators and contributors of this package may not be held liable for any damages, losses, issues, or problems caused resulting in the use of this package for any reason.

**EXPERIMENTAL NOTICE**
This package is under heavy development. Use at your own risk.
