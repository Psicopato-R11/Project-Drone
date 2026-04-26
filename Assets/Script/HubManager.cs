using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public CountUpTimer timer;
    public UImessage messageUI;
    public UImessage messageUI2;
    public float duration = 10f;

    void Start()
    {
        Debug.Log("HAS RESULT: " + RunResult.hasResult);
        Debug.Log("SPEED: " + RunResult.finalSpeed);
        Debug.Log("TIME: " + RunResult.finalTime);

        if (!RunResult.hasResult) return;

        timer.SetTime(RunResult.finalTime);
        timer.StopTimer();

        bool alreadyUnlocked = RunResult.accelechargerWasUnlocked;
        bool unlockedNow = RunResult.accelechargerUnlocked;

        messageUI2.ShowMessage("Reino Concluído.");

        if (unlockedNow && !alreadyUnlocked)
        {
            messageUI.ShowMessage("ACCELECHARGER DESBLOQUEADO");
        }
        else if (!alreadyUnlocked && !unlockedNow)
        {
            messageUI.ShowMessage("Você Falhou.");
        }

        

        RunResult.hasResult = false;

        StartCoroutine(LoadMenu());
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("Menu");
    }
}
