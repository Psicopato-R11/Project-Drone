using UnityEngine;
using TMPro; 

public class CountUpTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float elapsedTime { get; private set; }
    public bool isRunning = true;

    public float ElapsedTime => elapsedTime;

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        UpdateDisplay();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void SetTime(float time)
    {
        elapsedTime = time;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);


        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

}