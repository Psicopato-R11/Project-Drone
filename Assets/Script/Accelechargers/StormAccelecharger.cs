using UnityEngine;
using System.Collections;

public class StormAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Storm config")]
    public float duration = 45f;
    public Color effectColor = Color.yellow;

    private bool used = false;

    public bool isActive = false;
    public bool IsActive => isActive;
    public float Duration => duration;
    public Color EffectColor => effectColor;

    public void Activate()
    {
        if (used) return;
        used = true;
        isActive = true;
    }

    public void Deactivate()
    {

    }

    IEnumerator StormCoroutine ()
    {
        yield return new WaitForSeconds(duration);

        isActive = false;
    }
}
