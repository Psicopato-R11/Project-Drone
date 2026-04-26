using UnityEngine;
using TMPro;
using System.Collections;

public class UImessage : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI messageText;
    public float showTime = 2.5f;

    Coroutine currentRoutine;

    public void ShowMessage(string message)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        messageText.text = message;
        UI.SetActive(true);

        currentRoutine = StartCoroutine(HideAfterTime());
    }

    IEnumerator HideAfterTime()
    {
        yield return new WaitForSecondsRealtime(showTime);
        UI.SetActive(false);
    }
}
