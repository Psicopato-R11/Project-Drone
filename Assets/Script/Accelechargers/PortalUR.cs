using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalUR : MonoBehaviour
{
    private Rigidbody rigidbody;

    public void OnTriggerEnter(Collider other)
    {
        rigidbody = other.GetComponentInParent<Rigidbody>();

        UltimateRaceManager.Instance.storedVelocity = rigidbody.linearVelocity.magnitude;
        UltimateRaceManager.Instance.applyVelocityOnSpawn = true;

        UltimateRaceManager.Instance.RealmListSelector();
    }
 
}
