using UnityEngine;

public class OnHitSound : MonoBehaviour
{
    public AudioClip EfeitoSonoro;
    public float Volume;

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(
                EfeitoSonoro,
                 transform.position,
                 Volume
                );
        }
    }
}
