using UnityEngine;

public class WindPush : MonoBehaviour
{
    [Header("Wind Push configs")]
    
    public float WindForce = 1000f;
    public ForceMode forcemode;
    
    private Rigidbody rb;
    private WindAccelecharger windAccelecharger;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider que entrou: " + other);

        if (other.CompareTag("Player"))
        {
            rb = other.GetComponentInParent<Rigidbody>();
            windAccelecharger = other.GetComponentInParent<WindAccelecharger>(); 
        }
    }

    void OnTriggerStay()
    {
        if (!windAccelecharger.IsActive && rb != null)
        { 
                Vector3 localLeftDirection = -transform.right;

                rb.AddForce(localLeftDirection * WindForce, forcemode);
        }
    }

    void OnTriggerExit()
    {
        rb = null;
    }
}
