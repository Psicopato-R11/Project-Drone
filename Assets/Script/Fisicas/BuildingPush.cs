using UnityEngine;

public class BuildingPush : MonoBehaviour
{
    public Rigidbody rb;
    public float pushForce = 5000f;
    public ForceMode forcemode;
    public AudioSource rumbleAudio;

    public void OnTriggerEnter()
    {
        rb.AddForce(rb.transform.forward * pushForce, forcemode);
        rumbleAudio.Play();
    }
}
