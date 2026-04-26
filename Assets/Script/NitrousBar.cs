using UnityEngine;

public class NitrousBar : MonoBehaviour
{
    [Header("Refs")]
    public Renderer[] segments;
    public Nitrous nitrous;
    public float MaxNitro;
    public float CurrentNitro;


    void Update()
    {
        MaxNitro = nitrous.maxNitro;
        CurrentNitro = nitrous.currentNitro;

        float t = Mathf.Clamp01(CurrentNitro / MaxNitro);
        int activeSegments = Mathf.RoundToInt(t * segments.Length);

        for (int i = 0; i < segments.Length; i++)
        {
            bool active = i < activeSegments;
            Color color = Color.Lerp(Color.red, Color.green, t);

            segments[i].material.SetColor(
                "_EmissionColor",
                active ? color * 2.5f : Color.black
            );
        }
    }
}
