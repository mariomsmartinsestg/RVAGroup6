using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float elapsedTime;

    /// <summary>
    /// Initializes the timer and gets the TextMeshProUGUI reference.
    /// </summary>
    void Start()
    {
        // Initialize the timer
        elapsedTime = 0f;

        // Get the reference to TextMeshProUGUI
        if (timeText == null)
        {
            // If TextMeshProUGUI is not explicitly assigned, try to find it in the Canvas
            Canvas canvas = GetComponentInChildren<Canvas>();

            if (canvas != null)
                timeText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        }

        // Update the initial text
        UpdateTimeText();
    }

    /// <summary>
    /// Updates the timer each frame and refreshes the displayed text.
    /// </summary>
    void Update()
    {
        // Count the time
        elapsedTime += Time.deltaTime;

        // Update the text
        UpdateTimeText();
    }

    /// <summary>
    /// Formats the elapsed time as hours:minutes:seconds:milliseconds and updates the text.
    /// </summary>
    void UpdateTimeText()
    {
        // Format the time as hours:minutes:seconds:milliseconds
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

        // Update the text
        if (timeText != null)
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hours, minutes, seconds, milliseconds);
    }
}
