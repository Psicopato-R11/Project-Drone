using UnityEngine;
using TMPro;

public class URTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        float elapsedTime = UltimateRaceManager.Instance.raceTimer;


        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);


        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
