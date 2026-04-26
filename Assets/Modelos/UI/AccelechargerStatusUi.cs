using UnityEngine;
using TMPro;

public class AccelechargerStatusUi : MonoBehaviour
{
    public TextMeshProUGUI textoStatus;

    void Awake()
    {
        AccelechargerEvents.OnStatusChanged += AtualizarUI;
    }

    void OnDisable()
    {
        AccelechargerEvents.OnStatusChanged -= AtualizarUI;
    }

    void AtualizarUI(Color cor, string texto)
    {
        textoStatus.text = texto;
        textoStatus.color = cor;
    }

}
