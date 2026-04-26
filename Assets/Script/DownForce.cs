using UnityEngine;

public class DownForce : MonoBehaviour
{
    public float downForce = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        rb.AddForce(-transform.up * rb.velocity.magnitude * downForce);
    }
}
