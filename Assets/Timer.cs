using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Import for scene management
using UnityEngine.UI; // Import if you want to display the stopwatch on UI

public class Timer : MonoBehaviour
{
    private static float elapsedTime = 0f; // Time elapsed in seconds
    public bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void StartStopwatch()
    {
        isRunning = true; // Start the stopwatch
    }

    public void StopStopwatch()
    {
        isRunning = false; // Stop the stopwatch
    }

    public void ResetStopwatch()
    {
        isRunning = false; // Stop the stopwatch
        elapsedTime = 0f; // Reset elapsed time
    }

    public static float TotalTimeTaken()
    {
        return elapsedTime;
    }
}
