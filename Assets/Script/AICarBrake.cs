using UnityEngine;

public class AICarBrake : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CarAI ai = other.GetComponentInParent<CarAI>();
        if (ai != null)
        {
            ai.BrakeFor(1.5f);
        }
    }
}
