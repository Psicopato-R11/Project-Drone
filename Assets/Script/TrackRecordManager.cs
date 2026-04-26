using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackRecordManager : MonoBehaviour
{
    public TrackType trackType;
    public CountUpTimer timer;

    string Key => "BestTime_" + trackType.ToString();

    public void TrySaveRecord()
    {
        float time = timer.ElapsedTime;
        float best = PlayerPrefs.GetFloat(Key, -1f);

        if (best < 0 || time < best)
        {
            PlayerPrefs.SetFloat(Key, time);
            PlayerPrefs.Save();
            Debug.Log($" Novo recorde em {trackType}: {time}");
        }
    }
}
