using UnityEngine;

public class CraneLift : MonoBehaviour
{
    public float liftForce = 8000f;
    public float maxLiftTime = 1.2f;

    private float liftTimer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou no trigger com: " + other.name);
        if (other.CompareTag("Player"))
        {
            liftTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponentInParent<Rigidbody>();
            if (rb == null) return;

            if (liftTimer < maxLiftTime)
            {
                rb.AddForce(Vector3.up * liftForce * Time.deltaTime, ForceMode.Acceleration);
                liftTimer += Time.deltaTime;
            }
        }
        else
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb == null) return;

            if (liftTimer < maxLiftTime)
            {
                rb.AddForce(Vector3.up * liftForce * Time.deltaTime, ForceMode.Acceleration);
                liftTimer += Time.deltaTime;
            }
        }
        
    }
}
