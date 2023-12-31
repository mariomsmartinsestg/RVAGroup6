using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public Button stopButton;
    public Button startButton;
    public Button resetButton;

    private float elapsedTime;
    private bool isRunning = true; // Flag to track whether the timer is running

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

        // Assign the Stop button click event
        if (stopButton != null)
            stopButton.onClick.AddListener(StopTimer);

        // Update the initial text
        UpdateTimeText();
    }

    /// <summary>
    /// Updates the timer each frame and refreshes the displayed text.
    /// </summary>
    void Update()
    {
        // Count the time only if the timer is running
        if (isRunning)
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

    /// <summary>
    /// Stops the timer.
    /// </summary>
    void StopTimer()
    {
        isRunning = false;
    }


}
