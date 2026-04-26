using UnityEngine;
using TMPro;

public class SpeedBarUI : MonoBehaviour
{
    [Header("Refs")]
    public Rigidbody rb;
    public Renderer[] segments;
    public TextMeshProUGUI speedText;

    [Header("Config")]
    public float maxSpeed = 190f;
    public float smooth = 5f;

    private float smoothSpeed;

    void Update()
    {
        if (rb == null) return;

        float speed = rb.velocity.magnitude * 3.6f;
        smoothSpeed = Mathf.Lerp(smoothSpeed, speed, Time.deltaTime * smooth);

        // TEXTO
        speedText.text = Mathf.RoundToInt(smoothSpeed).ToString("0");

        // BARRA
        float t = Mathf.Clamp01(smoothSpeed / maxSpeed);
        int activeSegments = Mathf.RoundToInt(t * segments.Length);

        for (int i = 0; i < segments.Length; i++)
        {
            bool active = i < activeSegments;
            Color color = Color.Lerp(Color.green, Color.red, t);

            segments[i].material.SetColor(
                "_EmissionColor",
                active ? color * 2.5f : Color.black
            );
        }
    }
}
