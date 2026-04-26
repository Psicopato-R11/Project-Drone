using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class CarSelectionManager : MonoBehaviour
{
    [Header("Spawn e Carros")]
    public Transform SpawnPoint;
    public int index;
    public CarDatabase carDatabase;
    public GameObject currentCar;
    public AccelechargerUI UI;
    public bool isUR = false;
    public bool isHub = false;

    [Header("Camera")]
    public GameObject cameraObject;
    public SpeedBarUI speedBarUI;
    public NitrousBar nitrousBarUI;
    public TextMeshProUGUI speedText;

    [Header("Volume / Efeitos")]
    public UnityEngine.Rendering.Volume postProcessingVolume;
    public GameObject rainEffectPrefab; // arraste o prefab no inspector

    private GameObject currentRainEffect;
    private CarAI carAiScript;
    private Rigidbody rb;


    void Start()
    {

        index = PlayerPrefs.GetInt("carIndex", 0);
        index = Mathf.Clamp(index, 0, carDatabase.cars.Length - 1);

        currentCar = Instantiate(
        carDatabase.cars[index],
        SpawnPoint.position,
        SpawnPoint.rotation
        );
        rb = currentCar.GetComponent<Rigidbody>();
        ApplyCarProfile(currentCar);

        Nitrous nitro = currentCar.GetComponent<Nitrous>();

        speedBarUI.rb = rb;
        speedBarUI.speedText = speedText;

        nitrousBarUI.nitrous = nitro;


        if (rainEffectPrefab != null)
        {
            currentRainEffect = Instantiate(rainEffectPrefab);
            currentRainEffect.transform.SetParent(currentCar.transform);
            currentRainEffect.transform.localPosition = new Vector3(0, 2f, 0); // altura da chuva acima do carro
        }

        PlayerRespawn respawn = currentCar.GetComponent<PlayerRespawn>();
        if (respawn != null)
        {
            respawn.spawnPoint = SpawnPoint;
        }

        if (cameraObject != null)
        {
            CarCameraScript camScript = cameraObject.GetComponent<CarCameraScript>();
            if (camScript != null)
            {
                camScript.car = currentCar.transform;
                camScript.firstPersonLookAt = currentCar.transform.Find("FPS_Point");
            }

            SpeedBlur blurController = cameraObject.GetComponent<SpeedBlur>();
            if (blurController != null)
            { 
                blurController.carRigidbody = rb;
                blurController.volume = postProcessingVolume;
            }
        }
        else
        {
            Debug.LogWarning("Câmera não atribuída no Inspector!");
        }


        EyeLook[] allEyes = FindObjectsOfType<EyeLook>();
        foreach (EyeLook eye in allEyes)
            eye.eyeDest = currentCar.transform;

        // Atualiza todos os spotlights
        LuzLook[] allSpotlights = FindObjectsOfType<LuzLook>();
        foreach (LuzLook spotlight in allSpotlights)
            spotlight.target = currentCar.transform;

        CarAI[] allAI = FindObjectsOfType<CarAI>();
        foreach (CarAI AI in allAI)
        {
            if (AI.IsEnemy == true)
            {
                AI.PlayerTarget = currentCar.transform;
            }
        }

        if (isUR && UltimateRaceManager.Instance.applyVelocityOnSpawn)
        {
            StartCoroutine(ApplyURVelocity());
        }

        if (isHub && RunResult.hasResult)
        {
            StartCoroutine(ApplyURVelocity());
        }

    }

    void ApplyCarProfile(GameObject car)
    {
        CarProfile profile = car.GetComponent<CarProfile>();
        if (profile == null)
        {
            Debug.LogWarning("Carro sem CarProfile");
            return;
        }

        // CÂMERA
        if (cameraObject != null)
        {
            CarCameraScript cam = cameraObject.GetComponent<CarCameraScript>();
            if (cam != null)
            {
                cam.distance = profile.cameraDistance;
                cam.height = profile.cameraHeight;
            }
        }

        speedBarUI.maxSpeed = profile.maxSpeed;
    }

    private IEnumerator ApplyURVelocity()
    {
        // espera física
        yield return new WaitForFixedUpdate();

        if (rb == null || rb.Equals(null))
            yield break;

        rb.isKinematic = false;
        rb.Sleep();
        rb.WakeUp();

        if (isUR)
        {
            rb.velocity = SpawnPoint.forward * UltimateRaceManager.Instance.storedVelocity;
            UltimateRaceManager.Instance.applyVelocityOnSpawn = false;
        }    
        
        if (isHub)
        {
            rb.velocity = SpawnPoint.forward * RunResult.finalSpeed;
        }

        
    }
}
