using UnityEngine;
using System.Collections;

public class WindAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Wind config")]
    public float duration = 45f;
    public Color effectColor = Color.yellow;

    private bool used = false;

    public bool isActive = false;
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    public void Activate()
    {
        if (used) return;
        used = true;
        isActive = true;
        StartCoroutine(WindCoroutine());
    }

    public void Deactivate()
    {

    }

    IEnumerator WindCoroutine()
    {
        yield return new WaitForSeconds(duration);

        isActive = false;
    }
}
