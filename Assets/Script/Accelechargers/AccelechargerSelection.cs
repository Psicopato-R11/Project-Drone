using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AccelechargerSelection : MonoBehaviour
{
    [Header("Modelos")]
    public GameObject[] accelechargers;

    [Header("UI")]
    public Button next;
    public Button prev;
    public Button equipButton;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI EquipText;
    public AccelechargerUI powerUpUI;

    int index;

    void Start()
    {

        Debug.Log("Fog: " + PlayerPrefs.GetInt("Accelecharger_Fog", 0));
        Debug.Log("Lava: " + PlayerPrefs.GetInt("Accelecharger_Lava", 0));
        Debug.Log("Swamp: " + PlayerPrefs.GetInt("Accelecharger_Swamp", 0));
        Debug.Log("Fear: " + PlayerPrefs.GetInt("Accelecharger_Fear", 0));
        Debug.Log("Water: " + PlayerPrefs.GetInt("Accelecharger_Water", 0));
        Debug.Log("Ruins: " + PlayerPrefs.GetInt("Accelecharger_Ruins", 0));
        Debug.Log("Storm: " + PlayerPrefs.GetInt("Accelecharger_Storm", 0));
        Debug.Log("Time: " + PlayerPrefs.GetInt("Accelecharger_Time", 0));
        Debug.Log("Junk: " + PlayerPrefs.GetInt("Accelecharger_Junk", 0));
        Debug.Log("Metro: " + PlayerPrefs.GetInt("Accelecharger_Metro", 0));
        Debug.Log("Cosmic: " + PlayerPrefs.GetInt("Accelecharger_Cosmic", 0));
        Debug.Log("Wind: " + PlayerPrefs.GetInt("Accelecharger_Wind", 0));
        Debug.Log("Rain: " + PlayerPrefs.GetInt("Accelecharger_Rain", 0));
        Debug.Log("Sky: " + PlayerPrefs.GetInt("Accelecharger_Sky", 0));

        index = PlayerPrefs.GetInt("AccelechargerIndex", 0);
        ShowAccelecharger();
    }

    void Update()
    {
        prev.interactable = index > 0;
        next.interactable = index < accelechargers.Length - 1;

        UpdateUI();
    }

    void UpdateUI()
    {
        bool unlocked = PlayerPrefs.GetInt(
            "Accelecharger_" + ((AccelechargerUnlock.AccelechargerType)index),
            0
        ) == 1;

        equipButton.interactable = unlocked;

        int equippedCurrent = PlayerPrefs.GetInt("EquippedAccelecharger", -1);
        bool equipped = equippedCurrent == index;

        statusText.text = unlocked ? "Desbloqueado" : "Bloqueado";
        EquipText.text = equipped ? "Equipado" : "Equipar";
    }

    public void Next()
    {
        if (index < accelechargers.Length - 1)
        {
            index++;
            ShowAccelecharger();
            PlayerPrefs.SetInt("AccelechargerIndex", index);
            PlayerPrefs.Save();
        }
    }

    public void Prev()
    {
        if (index > 0)
        {
            index--;
            ShowAccelecharger();
            PlayerPrefs.SetInt("AccelechargerIndex", index);
            PlayerPrefs.Save();
        }
    }

    void ShowAccelecharger()
    {
        for (int i = 0; i < accelechargers.Length; i++)
            accelechargers[i].SetActive(false);

        accelechargers[index].SetActive(true);
    }

    public void Equip()
    {
        PlayerPrefs.SetInt("EquippedAccelecharger", index);
        PlayerPrefs.Save();

        Debug.Log("Accelecharger equipado: " +
            (AccelechargerUnlock.AccelechargerType)index);
    }
}
