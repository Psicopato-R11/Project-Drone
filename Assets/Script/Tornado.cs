using UnityEngine;

public class Tornado : MonoBehaviour
{
   
    public float Rotation;
    public float pullforce;

    private Rigidbody rb;
    private WindAccelecharger windAccelecharger;
    private Vector3 force;

    void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponentInParent<Rigidbody>();
        Debug.Log("Collider entrou no trigger");
        Debug.Log(rb);
        windAccelecharger = other.GetComponentInParent<WindAccelecharger>();
        Debug.Log(windAccelecharger);
    }

    void FixedUpdate()
    {
        if (rb == null) return;
        if (!windAccelecharger.IsActive)
        {
            
            force = (transform.position - rb.transform.position);

            force = Quaternion.Euler(0, Rotation, 0) * force;

            rb.AddForce(force.normalized * pullforce * Time.deltaTime, ForceMode.Acceleration);

        }   
    }

    void OnTriggerExit()
    {
        rb = null;
    }
}
