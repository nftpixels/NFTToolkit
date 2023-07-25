// ----------------------------------------------------------------------------
// Script name: DataManager.cs
// Author: Reinhardt Weyers
// Creation Date: July 25, 2023
// Description: A script that handles querying NFT metadata for use in blockchain games.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Dictionary to store the metadata based on the name (or other identifiers)
    private Dictionary<string, NFTToolkit.Metadata> metadataDictionary = new Dictionary<string, NFTToolkit.Metadata>();

    // Singleton instance
    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            // If the instance is null, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();

                // If it's still null, create a new GameObject and add the DataManager component to it
                if (instance == null)
                {
                    GameObject obj = new GameObject("DataManager");
                    instance = obj.AddComponent<DataManager>();
                }
            }
            return instance;
        }
    }

    // Function to add metadata to the dictionary
    public void AddMetadata(string name, NFTToolkit.Metadata metadata)
    {
        if (!metadataDictionary.ContainsKey(name))
        {
            metadataDictionary.Add(name, metadata);
        }
    }

    // Function to get metadata by name (or other identifiers)
    public NFTToolkit.Metadata GetMetadataByName(string name)
    {
        if (metadataDictionary.ContainsKey(name))
        {
            return metadataDictionary[name];
        }

        return null;
    }
}
