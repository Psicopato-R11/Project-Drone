using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R))
       {
            Respawn();
       }
    }


    void Respawn()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null && spawnPoint != null)
        {
          rb.velocity = Vector3.zero;
          rb.angularVelocity = Vector3.zero;
          rb.MovePosition(spawnPoint.position);
            rb.MoveRotation(spawnPoint.rotation);
        }
        
    }
}