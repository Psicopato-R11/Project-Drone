using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SpeedBlur : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public Volume volume;
    private DepthOfField dof;

    [Header("Configuração")]
    public float minSpeed = 0f;
    public float maxSpeed = 150f;
    public float minAperture = 4f;
    public float maxAperture = 16f;

    void Start()
    {
        if (volume.profile.TryGet(out dof))
        {
            Debug.Log("Depth of Field encontrado!");
        }
        else
        {
            Debug.LogError("Nenhum Depth of Field encontrado no Volume!");
        }
    }

    void Update()
    {
        if (carRigidbody == null || dof == null) return;

        float speed = carRigidbody.velocity.magnitude * 3.6f; // m/s ? km/h
        float t = Mathf.InverseLerp(minSpeed, maxSpeed, speed);

        dof.aperture.value = Mathf.Lerp(minAperture, maxAperture, t);
    }
}
