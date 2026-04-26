using UnityEngine;

public class PushBack : MonoBehaviour
{
    public float pushForce = 8f;        
    public float upForceMultiplier = 0.35f;
    public AudioClip EfeitoSonoro;
    public float Volume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 dir = (other.transform.position - transform.position).normalized;

            Vector3 force = (dir * pushForce) + (Vector3.up * (pushForce * upForceMultiplier));

            rb.AddForce(force, ForceMode.VelocityChange);

            AudioSource.PlayClipAtPoint(
                EfeitoSonoro,
                transform.position,
                Volume
                );
        }
    }
}
