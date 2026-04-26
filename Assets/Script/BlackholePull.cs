using UnityEngine;

public class BlackholePull : MonoBehaviour
{
    public float pullForce = 50f;
    public float killRadius = 1.5f;
    public float pullRadius = 15f;

    void FixedUpdate()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, pullRadius);

        foreach (Collider hit in hits)
        {
            Rigidbody rb = hit.attachedRigidbody;
            if (rb == null) continue;

            Vector3 direction = transform.position - rb.position;
            float distance = direction.magnitude;

            if (distance < killRadius)
            {
                Destroy(hit.gameObject);
                continue;
            }

            float force = pullForce / Mathf.Max(distance, 0.5f);
            rb.AddForce(direction.normalized * force, ForceMode.Acceleration);
        }
    }

    void OnDrawGizmos()
    {
        // Raio de puxão
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pullRadius);

        // Raio de destruição
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, killRadius);
    }
}
