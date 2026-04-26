using System.Collections;
using System.Text;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScrambleEffect : MonoBehaviour
{
    public TMP_FontAsset droneFont;
    public float totalDuration = 2f;
    public float decodeSpeed = 0.05f;

    private TMP_Text text;
    private string targetText;

    private const string scrambleChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        targetText = text.text;
    }

    void OnEnable()
    {
        text.text = targetText;

        StopAllCoroutines();
        StartCoroutine(DecodeRoutine());
    }

    IEnumerator DecodeRoutine()
    {
        int length = targetText.Length;
        int revealed = 0;

        float scrambleTimer = 0f;

        while (revealed < length)
        {
            scrambleTimer += Time.deltaTime;

            // controla o ritmo de decodificação
            if (scrambleTimer >= decodeSpeed)
            {
                revealed++;
                scrambleTimer = 0f;
            }

            StringBuilder builder = new StringBuilder();

            // Parte decodificada (fonte normal)
            builder.Append(targetText.Substring(0, revealed));

            // Parte embaralhada (fonte dos drones)
            if (revealed < length)
            {
                builder.Append($"<font=\"{droneFont.name}\">");

                for (int i = revealed; i < length; i++)
                {
                    char randomChar =
                        scrambleChars[Random.Range(0, scrambleChars.Length)];
                    builder.Append(randomChar);
                }

                builder.Append("</font>");
            }

            text.text = builder.ToString();
            yield return null;
        }

        // garante texto final limpo
        text.text = targetText;
    }
}