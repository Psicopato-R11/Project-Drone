using UnityEngine;
using System.Collections;

public class MetroAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Metro Config")]
    public GameObject Shield;
    public Color effectColor = Color.yellow;
    public float duration = 30f;

    private bool used = false;
    private bool isActive = false;

    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    public void Activate()
    {
        if (used) return;

        used = true;
        Debug.Log("Foi chamado");
        StartCoroutine(MetroShield());
    }

    public void Deactivate()
    {
        if (!isActive) return;

        isActive = false;
    }

    IEnumerator MetroShield()
    {
        if (Shield != null)
        {
        Shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        Shield.SetActive(false);
        }
        
    }
}
