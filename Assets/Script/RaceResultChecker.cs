using UnityEngine;

public class RaceResultChecker : MonoBehaviour
{
    public RaceTimer timer;

    public void OnRaceFinished()
    {
        if (timer == null) return;

        if (timer.FinishedInTime())
        {
            Debug.Log("Vitória!");
            UnlockAccelecharger();
        }
        else
        {
            Debug.Log("Derrota!");
        }
    }

    void UnlockAccelecharger()
    {
        PlayerPrefs.SetInt("Accelecharger_" + timer.currentTrack, 1);
        PlayerPrefs.Save();
    }
}
