using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TimeScaledAudioCar : MonoBehaviour
{
    private AudioSource engineSource;

    public float minPitch = 0.3f;
    public float maxPitch = 2.5f;
    public float smoothSpeed = 5f;

    private float currentPitchMultiplier = 1f;

    void Start()
    {
        engineSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // O pitch que o Prometeo já calculou
        float basePitch = engineSource.pitch;

        // Alvo do multiplicador baseado no tempo do jogo
        float targetMultiplier = Mathf.Clamp(Time.timeScale, 0.3f, 2f);

        // Suaviza a transição
        currentPitchMultiplier = Mathf.Lerp(
            currentPitchMultiplier,
            targetMultiplier,
            Time.unscaledDeltaTime * smoothSpeed
        );

        // Aplica o multiplicador sem quebrar o Prometeo
        float finalPitch = basePitch * currentPitchMultiplier;

        // Limita o resultado final
        engineSource.pitch = Mathf.Clamp(finalPitch, minPitch, maxPitch);
    }
}
