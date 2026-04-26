using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    public TrackType currentTrack;
    public float timeLimit = 120f;

    public float currentTime { get; private set; }
    public bool timeUp { get; private set; }

    void Update()
    {
        if (timeUp) return;

        currentTime += Time.deltaTime;

        if (currentTime >= timeLimit)
        {
            timeUp = true;
            Debug.Log("Tempo esgotado!");
        }
    }

    public bool FinishedInTime()
    {
        return currentTime <= timeLimit;
    }
}
