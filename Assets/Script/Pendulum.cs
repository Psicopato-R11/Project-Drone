using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 2f;       // Velocidade da oscilação
    public float angle = 45f;      // Ângulo máximo para cada lado

    private Vector3 startRotation;

    void Start()
    {
        startRotation = transform.localEulerAngles;
    }

    void Update()
    {
        float rotation = angle * Mathf.Sin(Time.time * speed);
        transform.localEulerAngles = new Vector3(
           startRotation.x,
           startRotation.y,
           startRotation.z + rotation
        );
    }
}
