using System.Collections;
using UnityEngine;

public class TimedObstacleActivator : MonoBehaviour
{
    [Header("Referências")]
    public GameObject obstacleObject;    
    public float activationDelay = 2f;  
    public float activeDuration = 3f;   
    private bool isTriggered = false;

    private void Start()
    {
      
        if (obstacleObject != null)
            obstacleObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!isTriggered && other.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("[OBSTÁCULO] Carro entrou no gatilho, iniciando sequência...");
            StartCoroutine(ActivateObstacleSequence());
        }
    }

    private IEnumerator ActivateObstacleSequence()
    {
        
        yield return new WaitForSeconds(activationDelay);

        
        Debug.Log("[OBSTÁCULO] Obstáculo ativado");
        obstacleObject.SetActive(true);

        
        yield return new WaitForSeconds(activeDuration);

       
        obstacleObject.SetActive(false);
        Debug.Log("[OBSTÁCULO] Obstáculo desativado");

        isTriggered = false;
    }
}
