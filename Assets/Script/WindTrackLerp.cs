using UnityEngine;

public class WindTrackLerp : MonoBehaviour
{
    [Header("Moving track")]
    
    public float distance = 3f;
    public float lerpSpeed = 10f;

    public bool Xaxis = true;
    public bool Zaxis = false;

    private Vector3 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }
    
    void Update()
    {
        float time = Mathf.PingPong(Time.time * lerpSpeed, 1);
        if (Xaxis)
        {
            Vector3 leftPos = StartPos - new Vector3(distance, 0, 0);
            Vector3 rightPos = StartPos + new Vector3(distance, 0, 0);

            transform.position = Vector3.Lerp(leftPos, rightPos, time);
        }

        if (Zaxis)
        {
            Vector3 frontPos = StartPos - new Vector3(0, 0, distance);
            Vector3 backPos = StartPos + new Vector3(0, 0, distance);

            transform.position = Vector3.Lerp(frontPos, backPos, time);
        }
        
    }
}
