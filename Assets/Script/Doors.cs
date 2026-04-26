using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour
{
    public Vector3 moveDistance = new Vector3(0, 5, 0); // Distance to move
    public float duration = 1.0f; // Time in seconds
    public AudioSource openDoor;

    private bool isOpen = false;

    // Call this method (e.g., via trigger or click)
    public void Move()
    {
        if (!isOpen)
        {
            StartCoroutine(MoveDoor(transform.position + moveDistance));
            if (openDoor != null) openDoor.Play();
            isOpen = true;
        }
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Smoothly interpolate position
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        transform.position = targetPosition; // Ensure exact final position
    }
}