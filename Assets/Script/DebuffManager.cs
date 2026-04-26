using System.Collections;
using UnityEngine;

public class CarDebuffHandler : MonoBehaviour
{
    private PrometeoCarController carController;
    private rayzngames.BicycleVehicle bikeController;
    public bool isBike = false;

    private void Start()
    {
        if (!isBike)
        {
            carController = GetComponentInParent<PrometeoCarController>();
        }
        else
        {
            bikeController = GetComponentInParent<rayzngames.BicycleVehicle>();
        }
        
    }

    public void ApplyDisableDebuff(float duration)
    {
        StartCoroutine(DisableCarCoroutine(duration));
    }

    private IEnumerator DisableCarCoroutine(float duration)
    {
        if (!isBike && carController != null)
        {
            carController.enabled = false;
            yield return new WaitForSeconds(duration);
            carController.enabled = true;
        }
        else if (isBike && bikeController != null)
        {
            bikeController.enabled = false;
            yield return new WaitForSeconds(duration);
            bikeController.enabled = true;
        }

    }
}
