using UnityEngine;

public class AccelechargerPanelDisplay : MonoBehaviour
{
    [Header("Modelos do Painel")]
    public GameObject[] accelechargerModels;

    void OnEnable()
    {
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        int equipped = PlayerPrefs.GetInt("EquippedAccelecharger", -1);

        // Desliga todos
        for (int i = 0; i < accelechargerModels.Length; i++)
            accelechargerModels[i].SetActive(false);

        // Nada equipado
        if (equipped < 0 || equipped >= accelechargerModels.Length)
            return;

        // Ativa só o equipado
        accelechargerModels[equipped].SetActive(true);
    }
}