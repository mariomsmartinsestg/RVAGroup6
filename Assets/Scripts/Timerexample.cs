using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class Timerexample : MonoBehaviour
{

    float val;
    bool srt;
    public Text disvar;

    public TextMeshProUGUI timeText;
    public Button stopButton;
    public Button startButton;
    public Button resetButton;

    public float elapsedTime;
    private bool isRunning = false; // Flag to track whether the timer is running

    /// <summary>
    /// Initializes the timer and gets the TextMeshProUGUI reference.
    /// </summary>
    void Start()
    {
        // Initialize the timer
        elapsedTime = 0f;

        // Assign the Start button click event
        if (startButton != null)
            startButton.onClick.AddListener(startbutton);

        // Assign the Stop button click event
        if (stopButton != null)
            stopButton.onClick.AddListener(stopbutton);

        // Assign the Reset button click event
        if (resetButton != null)
            resetButton.onClick.AddListener(resetbutton);

    }

    /// <summary>
    /// Updates the timer each frame and refreshes the displayed text.
    /// </summary>
    void Update()
    {
        // Count the time only if the timer is running
        if (isRunning) { 
            elapsedTime += Time.deltaTime;

        // Update the text
        UpdateTimeText();
        }
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

    public void stopbutton()
    {
        isRunning = false;
        Debug.Log("stop");

    }
    public void resetbutton()
    {
        isRunning = false;
        elapsedTime = 0;
        UpdateTimeText();
        Debug.Log("reset");

    }
    public void startbutton()
    {
        isRunning = true;
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
        Debug.Log("start");
    }
}