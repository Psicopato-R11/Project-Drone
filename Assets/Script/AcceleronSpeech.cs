using UnityEngine;
using System.Collections;

public class AcceleronSpeech : MonoBehaviour
{
    public UImessage messageUI;
    public float delay = 1f;

    void Start()
    {
        messageUI.ShowMessage("Muito bem.");
        StartCoroutine(Speech());
    }

    IEnumerator Speech()
    {
        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("É impressionante que uma máquina tenha chegado até aqui.");

        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("Mas...");

        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("Era de se esperar.");

        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("Afinal, você é minha criação.");

        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("Ainda assim...");

        yield return new WaitForSeconds(delay);

        messageUI.ShowMessage("Você realmente compreendeu o teste?");
    }


    
}
