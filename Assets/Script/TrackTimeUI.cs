using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TrackTimeUI : MonoBehaviour
{
    [Header("Config")]

    public TrackType trackType;
    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        float best = PlayerPrefs.GetFloat(
            "BestTime_" + trackType.ToString(),
            -1f
        );

        if (best < 0)
        {
            bestTimeText.text = "--:--:--";
        }
        else
        {
            int min = Mathf.FloorToInt(best / 60);
            int sec = Mathf.FloorToInt(best % 60);
            int ms = Mathf.FloorToInt((best * 100) % 100);

            bestTimeText.text = $"{min:00}:{sec:00}:{ms:00}";
        }
    }
}
