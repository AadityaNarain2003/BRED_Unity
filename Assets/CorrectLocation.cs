using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CorrectLocation : MonoBehaviour
{
    private static int count=0;

    private static Dictionary<string, Vector3> spawnedObjects;
    void Start()
    {
        Debug.Log("IN RECALL");
        spawnedObjects = ObjectSpawner.GetSpawnedObjects();
        //count=2;
        //TestSpawnedObjects();
    }

    void TestSpawnedObjects()
    {
        if (spawnedObjects.Count == 0)
        {
            Debug.Log("No objects have been spawned.");
            return;
        }

        // Loop through the dictionary to check each object's position
        foreach (var kvp in spawnedObjects)
        {
            string objectName = kvp.Key;
            Vector3 expectedPosition = kvp.Value;

            // Try to find the object in the current scene
            GameObject foundObject = GameObject.Find(objectName);
            if (foundObject != null)
            {
                // Compare the object's position with the expected position
                if (Vector3.Distance(foundObject.transform.position, expectedPosition) < 0.6f)
                {
                    Debug.Log($"{objectName} is at the correct location: {foundObject.transform.position}");
                }
                else
                {
                    Debug.Log($"{objectName} is NOT at the correct location. Expected: {expectedPosition}, Found: {foundObject.transform.position}");
                }
            }
            else
            {
                Debug.Log($"{objectName} not found in the scene.");
            }
            
        }
        count=5;
    }

    public static void CheckSpawnedObjects()
    {
        spawnedObjects = ObjectSpawner.GetSpawnedObjects();
        if (spawnedObjects == null || spawnedObjects.Count == 0)
        {
            Debug.Log("No objects have been spawned.");
            count=100;
            return;
        }

        // Loop through the dictionary to check each object's position
        foreach (var kvp in spawnedObjects)
        {
            string objectName = kvp.Key;
            Vector3 expectedPosition = kvp.Value;

            // Try to find the object in the current scene
            GameObject foundObject = GameObject.Find(objectName);
            if (foundObject != null)
            {
                // Compare the object's position with the expected position
                if (Vector3.Distance(foundObject.transform.position, expectedPosition) < 0.6f)
                {
                    count++;
                    Debug.Log($"{objectName} is at the correct location: {foundObject.transform.position}");
                }
                else
                {
                    Debug.Log($"{objectName} is NOT at the correct location. Expected: {expectedPosition}, Found: {foundObject.transform.position}");
                }
            }
            else
            {
                Debug.Log($"{objectName} not found in the scene.");
            }
        }
    }
    public static int GetCorrectOutcome()
    {
        return count;
    }
}

