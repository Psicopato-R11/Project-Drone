using UnityEngine;

public class TimeScaledAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Ajusta o pitch baseado no timeScale
        audioSource.pitch = Time.timeScale;

        // Evita pitch muito baixo ficar estranho
        if (audioSource.pitch < 0.1f)
            audioSource.pitch = 0.1f;
    }
}
