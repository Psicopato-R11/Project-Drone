using UnityEngine;

public class MeteorLauncher : MonoBehaviour
{
    [Header("Meteor Settings")]
    public Transform[] SpawnPoints;
    public GameObject MeteorPrefab;
    public float predictionValue = 2f;
    public float duration = 10f;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LaunchMeteor(other.gameObject);
            Debug.Log("O collider que entrou: " + other);
        }
        
    }


    void LaunchMeteor (GameObject target)
    {
        
        
        Transform selectedSpawn = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

        GameObject currentMeteor = Instantiate(MeteorPrefab, selectedSpawn.position, selectedSpawn.rotation, null);

        Debug.Log("Instanciado");

        Rigidbody rb_Player = target.GetComponentInParent<Rigidbody>();
        Debug.Log(rb_Player);

        Vector3 FuturePosition = target.transform.position + (rb_Player.velocity * predictionValue);
        Debug.Log(FuturePosition);

        MeteoroPerseguidor pursuer = currentMeteor.GetComponent<MeteoroPerseguidor>();
        if (pursuer != null)
        {
            pursuer.SetTarget(FuturePosition);
        }

    }
}
