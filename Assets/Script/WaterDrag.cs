using UnityEngine;

public class WaterDrag : MonoBehaviour
{
    [Header("Water Drag Value")]
    public float waterDragStrength = 5f;

    private Rigidbody carRb;
    private bool carInWater = false;

    void OnTriggerEnter(Collider other)
    {
        // Try to get the Rigidbody from the object or its parent (common for Prometeo)
        carRb = other.GetComponentInParent<Rigidbody>();
        if (carRb != null)
        {
            carInWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>() == carRb)
        {
            carInWater = false;
            carRb = null;
        }
    }

    void FixedUpdate()
    {
        if (carInWater && carRb != null)
        {
            // Apply a force in the opposite direction of current movement
            // Using ForceMode.Acceleration makes the effect consistent across all cars
            Vector3 resistanceForce = -carRb.velocity * waterDragStrength;
            carRb.AddForce(resistanceForce, ForceMode.Acceleration);
        }
    }
}
