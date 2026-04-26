using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalRaceUnlock : MonoBehaviour
{
    [Header("UI / Pista Final")]
    public Button finalTrackButton;
    public int MinAccelechargers = 14;
    public AudioSource unlockSound;
    public float duration = 1.5f;
    const string botao_apareceu = "Apareceu pela primeira vez.";

    void Start()
    {
        int actionValue = PlayerPrefs.GetInt(botao_apareceu, 0);

        if (actionValue == 0)
        {
                if (AreAllAccelechargersUnlocked())
                {
                    StartCoroutine(ShowButton());
                }
            PlayerPrefs.SetInt(botao_apareceu, 1);
        }
        else
        {
            finalTrackButton.gameObject.SetActive(AreAllAccelechargersUnlocked());
        }
        
            
    }

    bool AreAllAccelechargersUnlocked()
    {
        int count = 0;
        // Percorre todos os tipos de Accelecharger no Enum
        foreach (AccelechargerUnlock.AccelechargerType type in
                 System.Enum.GetValues(typeof(AccelechargerUnlock.AccelechargerType)))
        {
            string key = "Accelecharger_" + type.ToString();

            // Se o valor for 1, o jogador possui esse item
            if (PlayerPrefs.GetInt(key, 0) == 1)
            {
                count++;
            }
        }

        // Verifica se o jogador atingiu a meta de accelechargers
        if (count >= MinAccelechargers)
        {
            Debug.Log($"Corrida final desbloqueada! Total de Accelechargers: {count}");
            return true;
        }

        return false;
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(duration);

        finalTrackButton.gameObject.SetActive( AreAllAccelechargersUnlocked());

        if (unlockSound != null)
        {
            unlockSound.Play();
        }
        
    }
}
