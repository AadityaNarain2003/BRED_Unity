using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawnerRecall : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of 8 game objects
    public Vector3[] spawnLocations; // Array of 8 spawn locations

    void Start()
    {
        SpawnObjectsRecall();
    }

    void SpawnObjectsRecall()
    {
        // Ensure we have enough spawn locations
        if (spawnLocations.Length < 8)
        {
            Debug.LogError("Not enough spawn locations!");
            return;
        }

        // Create a list to track which objects have been selected
        bool[] selected = new bool[objectsToSpawn.Length];

        for (int i = 0; i < 8; i++)
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

        }
    }
}
