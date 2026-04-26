using UnityEngine;

public class MetroShield : MonoBehaviour
{
    [Header("Shield Config")]
    public float pushForce = 8f;
    public float upForceMultiplier = 0.35f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            return;

        Rigidbody rb = other.attachedRigidbody;

        Debug.Log("Shield colidiu com: " + other.name);

        if (rb != null)
        {
            Vector3 dir = (other.transform.position - transform.position).normalized;

            Vector3 force = (dir * pushForce) + (Vector3.up * (pushForce * upForceMultiplier));

            rb.AddForce(force, ForceMode.VelocityChange);

        }
    }
}
