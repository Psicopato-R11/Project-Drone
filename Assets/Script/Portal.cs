using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameManager gameManager;
    public CountUpTimer timer;
    public UImessage uiMessage;
    public TrackRecordManager recordManager;
    public AccelechargerUnlock accelechargerUnlock;
    public float timeLimitSeconds = 180f;
    public bool isTutorial = false;

    private Rigidbody carRb;
    private bool unlockedNow = false;

    void Start()
    {
        accelechargerUnlock = GetComponent<AccelechargerUnlock>();
    }

    void Update()
    {
        if(timer.elapsedTime >= timeLimitSeconds)
        {
            timer.timerText.color = Color.red;
        }
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        if (isTutorial)
        {
            SceneManager.LoadScene("Menu");
        }
        
        carRb = other.GetComponentInParent<Rigidbody>();

        bool wasUnlocked = accelechargerUnlock != null && accelechargerUnlock.IsUnlocked();

        RunResult.accelechargerWasUnlocked = wasUnlocked;

        if (recordManager != null)
        {
           recordManager.TrySaveRecord();
        }

        if (carRb != null)
        {
            RunResult.finalSpeed = carRb.velocity.magnitude;
        }
        else
        {
            Debug.LogWarning("Portal: Rigidbody do carro não encontrado");
            RunResult.finalSpeed = 0f;
        }

        RunResult.finalTime = timer.ElapsedTime;

        if (!wasUnlocked && timer.elapsedTime <= timeLimitSeconds)
        {
            accelechargerUnlock.Unlock();
            RunResult.accelechargerUnlocked = true;
        }
        else
        {
            RunResult.accelechargerUnlocked = false;
        }
        
        RunResult.hasResult = true;

        timer.StopTimer();

        SceneManager.LoadScene("Hub");
    }

    
}
