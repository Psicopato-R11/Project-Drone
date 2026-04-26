using UnityEngine;

public class Nitrous : MonoBehaviour
{
    [Header("Efeitos")]
    public GameObject nitrousEffect;
    public AudioSource audioSource;
    public AudioClip NitroAudioClip;

    [Header("Força")]
    public float boostForce = 1000f;

    [Header("Barra de Nitro")]
    public float maxNitro = 100f;
    public float currentNitro;
    public float nitroConsumptionRate = 30f; // por segundo

    [Header("Mesh Renderer")]
    public Renderer[] rearWheelRenderers;
    public Color glowColor = Color.cyan;
    public float baseIntensity = 0.5f;
    public float boostIntensity = 3f;

    private Color[] baseEmissions;
    private Rigidbody rb;
    private bool isBoosting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentNitro = maxNitro;

        baseEmissions = new Color[rearWheelRenderers.Length];

        for (int i = 0; i < rearWheelRenderers.Length; i++)
        {
            if (rearWheelRenderers[i].material.HasProperty("_EmissionColor"))
            {
                baseEmissions[i] = rearWheelRenderers[i].material.GetColor("_EmissionColor");
                rearWheelRenderers[i].material.EnableKeyword("_EMISSION");
            }
        }

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = NitroAudioClip;
    }

    void Update()
    {
        bool nitroInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (nitroInput && currentNitro > 0f)
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }

        if (isBoosting)
        {
            currentNitro -= nitroConsumptionRate * Time.deltaTime;
            currentNitro = Mathf.Clamp(currentNitro, 0f, maxNitro);

            if (!audioSource.isPlaying)
                audioSource.Play();

            nitrousEffect.SetActive(true);
            SetWheelGlow(true);
        }
        else
        {
            nitrousEffect.SetActive(false);
            SetWheelGlow(false);
        }
    }

    void FixedUpdate()
    {
        if (isBoosting && currentNitro > 0f)
        {
            rb.AddForce(transform.forward * boostForce, ForceMode.Acceleration);
        }
    }

    void SetWheelGlow(bool active)
    {
        for (int i = 0; i < rearWheelRenderers.Length; i++)
        {
            if (rearWheelRenderers[i].material.HasProperty("_EmissionColor"))
            {
                Color emission = active
                    ? glowColor * boostIntensity
                    : baseEmissions[i] * baseIntensity;

                rearWheelRenderers[i].material.SetColor("_EmissionColor", emission);
                rearWheelRenderers[i].material.EnableKeyword("_EMISSION");
            }
        }
    }
}