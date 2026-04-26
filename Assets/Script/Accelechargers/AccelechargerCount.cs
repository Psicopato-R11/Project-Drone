using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AccelechargerCount : MonoBehaviour
{
    public TextMeshProUGUI QuantText;

    void Start()
    {
        AccelechargerQuant();
    }

    public void AccelechargerQuant()
    {
        int count = 0;

        foreach (AccelechargerUnlock.AccelechargerType type in System.Enum.GetValues(typeof(AccelechargerUnlock.AccelechargerType)))
        {
            string key = "Accelecharger_" + type.ToString();

            if (PlayerPrefs.GetInt(key, 0) == 1)
            {
                count++;
            }
        }

        QuantText.text = count + "/14";
    }
}
