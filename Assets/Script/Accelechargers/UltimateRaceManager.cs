using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UltimateRaceManager : MonoBehaviour
{
    public static UltimateRaceManager Instance;

    public float raceTimer = 0f;
    public bool TimerIsActive = false;

    public float storedVelocity;
    public bool applyVelocityOnSpawn = false;

    public Rigidbody rb;
    public string sceneToLoad;

    public AccelechargerHandler testFailed;

    public bool unlockCar = true;

    public static List<string> availableScenes = new List<string>();


    public static List<string> defaultScenes = new List<string>()
    {
        "UR_FogRealm",
        "UR_LavaRealm",
        "UR_SwampRealm",
        "UR_FearRealm",
        "UR_WaterRealm",
        "UR_RuinsRealm",
        "UR_StormRealm",
        "UR_TimeRealm",
        "UR_JunkRealm",
        "UR_MetroRealm",
        "UR_CosmicRealm",
        "UR_WindRealm",
        "UR_RainRealm",
        "UR_SkyRealm"

    };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            ResetUltimateRace();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (TimerIsActive)
        {
            raceTimer += Time.deltaTime;
        }

    }

    public void RealmListSelector()
    {
        if (availableScenes.Count > 0)
        {
            int randomIndex = Random.Range(0, availableScenes.Count);
            sceneToLoad = availableScenes[randomIndex];
            availableScenes.RemoveAt(randomIndex);

            if (sceneToLoad != "UR_CosmicRealm")
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }

            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Reino escolhido: " + sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene("AcceleronBridge");
        }
    }

    public void ResetUltimateRace()
    {
        raceTimer = 0f;
        TimerIsActive = false;

        storedVelocity = 0f;
        applyVelocityOnSpawn = false;

        unlockCar = true;

        availableScenes.Clear();
        availableScenes.AddRange(defaultScenes);

        Debug.Log("Ultimate Race resetada (mesmo script)");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AcceleronTest();
        if (scene.name == "Menu")
        {
            ResetUltimateRace();
        }
    }

    private void AcceleronTest()
    {
        if (testFailed == null) return;
        if (testFailed.used)
        {
            Debug.Log("O player falhou o teste.");

            unlockCar = false;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}