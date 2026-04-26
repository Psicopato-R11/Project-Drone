using UnityEngine;

public class gameOver : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            gameManager.GameOver();
        }
    }
}