using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign your UI Text in Inspector
    private float elapsedTime;
    private bool isRunning;

    void Update()
    {
        if (isRunning)
        {
            // Add time passed since the last frame
            elapsedTime += Time.deltaTime;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        // Format as Minutes : Seconds : Milliseconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void StartStopwatch() => isRunning = true;
    public void StopStopwatch() => isRunning = false;
    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0;
        UpdateDisplay();
    }
}