using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Import for scene management
using UnityEngine.UI; // Import if you want to display the stopwatch on UI
using TMPro; // Import for TextMesh Pro 

public class Stopwatch : MonoBehaviour
{
    private float elapsedTime = 0f; // Time elapsed in seconds
    public bool isRunning = true;

    // Optional: Reference to a UI Text to display the stopwatch
    public TextMeshProUGUI[]  stopwatchText;

    public float stoptime= 10f;
    // Scene to load after 300 seconds
    public string sceneToLoad; // Name of the scene to load

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateStopwatchDisplay();

            // Check if elapsed time reaches 300 seconds
            if (elapsedTime >= stoptime)
            {
                SwitchScene();
            }
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
        UpdateStopwatchDisplay(); // Update display to show 00:00
    }

    void UpdateStopwatchDisplay()
    {
        if (stopwatchText != null)
        {
            // Convert elapsed time to minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            for(int i=0;i< stopwatchText.Length;i++)
            {
                stopwatchText[i].text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    void SwitchScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
