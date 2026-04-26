using UnityEngine;
using System.Collections;

public class SwampAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("SwampConfigs")]
    public Color effectColor = Color.yellow;
    public GameObject vinesPrefab;
    public float duration = 15f;
    public float distance = 10f;
    public Transform VineSpawnLocation;
    public Transform VineSpawnLocationForward;
    public Transform PlayerLocation;

    private GameObject[] Vines;
    private GameObject currentVine;
    private Vector3 lastDestinationPos;
    private Vector3 carRotation;
    private Quaternion lockedRotation;
    private bool isSwampActivated = false;

    private bool isActive = false;

    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    public void Activate()
    {
        if (isActive) return;
        isActive = true;

        StartCoroutine(SwampActivate());
        Debug.Log("Coroutine iniciada.");

    }

    public void Deactivate()
    {
        if (!isActive) return;

        isActive = false;
    }

        void Start()
    {
        if (PlayerLocation != null)
        {
            lastDestinationPos = PlayerLocation.position;
        }
    }

    void Update()
    {
        carRotation = PlayerLocation.eulerAngles;

        lockedRotation = Quaternion.Euler(0, carRotation.y, 0);

        if (isActive)
        {

                if (isSwampActivated && PlayerLocation != null && VineSpawnLocation != null && vinesPrefab != null)  
                {
                    Vector3 currentPlayerPos = PlayerLocation.position;

                    float distanceMoved = Vector3.Distance(lastDestinationPos, currentPlayerPos);

                    if (distanceMoved > distance)
                    {
                        Instantiate(vinesPrefab, VineSpawnLocationForward.position, lockedRotation);
                        lastDestinationPos = currentPlayerPos;
                        Debug.Log("Vinha instanciada");
                    }
                    Debug.Log("Distância calculada = " + distanceMoved);
                }
            
        }

        
       
    }
    
    IEnumerator SwampActivate()
    {
        isSwampActivated = true;

        Instantiate(vinesPrefab, VineSpawnLocation.position, lockedRotation);

        yield return new WaitForSeconds(duration);

        isSwampActivated = false;

        Vines = GameObject.FindGameObjectsWithTag("Vine");

        foreach (GameObject Vine in Vines)
        {
            Destroy(Vine);
            Debug.Log("Vinhas desativadas.");
        }

    }
}
