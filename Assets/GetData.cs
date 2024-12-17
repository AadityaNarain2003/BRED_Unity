using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro

public class GetData : MonoBehaviour
{
    public TextMeshProUGUI firstDataText;  // Assign this in the Inspector
    public TextMeshProUGUI secondDataText; // Assign this in the Inspector

    void Start()
    {
        // Call the static functions and print their data to the TMP text
        DisplayData();
    }

    private void DisplayData()
    {
        firstDataText.text = Timer.TotalTimeTaken().ToString();   // Set the first TMP text
        secondDataText.text = CorrectLocation.GetCorrectOutcome().ToString();  // Set the second TMP text

        Debug.Log(firstDataText.text);   // Optional: Print to console
        Debug.Log(secondDataText.text);  // Optional: Print to console
    }
}

