using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of 8 game objects
    public Vector3[] spawnLocations; // Array of 4 spawn locations

    private static Dictionary<string, Vector3> spawnedObjects = new Dictionary<string, Vector3>(); // Dictionary to store object names and their spawn locations

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        // Ensure we have enough spawn locations
        if (spawnLocations.Length < 4)
        {
            Debug.LogError("Not enough spawn locations!");
            return;
        }

        // Create a list to track which objects have been selected
        bool[] selected = new bool[objectsToSpawn.Length];

        for (int i = 0; i < 4; i++)
        {
            int randomIndex;

            // Find a unique random index
            do
            {
                randomIndex = Random.Range(0, objectsToSpawn.Length);
            } while (selected[randomIndex]);

            selected[randomIndex] = true; // Mark this object as selected

            // Instantiate the object at the corresponding spawn location
            GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawnLocations[i], Quaternion.identity);

            // Store the object name and its spawn location in the dictionary
            spawnedObjects.Add(spawnedObject.name, spawnLocations[i]);

            // Optional: Print the spawned object and its location for debugging
            Debug.Log($"Spawned {spawnedObject.name} at {spawnLocations[i]}");
        }

        // You can access the stored names and locations later if needed
        //foreach (var kvp in spawnedObjects)
        //{
        //    Debug.Log($"Stored Spawned Object: {kvp.Key} at Location: {kvp.Value}");
        //}
    }
    // Method to get the spawned objects dictionary
    public static Dictionary<string, Vector3> GetSpawnedObjects()
    {
        return spawnedObjects;
    }
}
