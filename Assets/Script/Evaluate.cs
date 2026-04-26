using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Evaluate : MonoBehaviour
{
    public Doors doors;
    public Doors doors2;
    public UImessage messageUI;

    public void OnTriggerEnter()
    {
        if (UltimateRaceManager.Instance.unlockCar)
        {
            messageUI.ShowMessage("Você compreendeu.");
            doors.Move();
            doors2.Move();
        }
        else
        {
            messageUI.ShowMessage("Velocidade sem compreensão... é falha.");
            StartCoroutine(Fail());
        }
    }

    IEnumerator Fail()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Menu");
    }
}
