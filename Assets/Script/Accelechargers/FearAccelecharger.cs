using UnityEngine;
using System.Collections;

public class FearAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Fear config")]
    public Color effectColor = Color.yellow;
    public GameObject Efeito;
    public float duration = 15f;
    public float boostForce = 10f;

    private bool used = false;
    private Rigidbody rb;
    private Coroutine activeRoutine;
    private bool isActive = false;

    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        if (used) return;
        Debug.Log("Fear ativado");
        used = true;
        isActive = true;
        activeRoutine = StartCoroutine(FearRoutine());
    }

    public void Deactivate()
    {
        if (!isActive) return;

        isActive = false;
        if (activeRoutine != null)
        {
            StopCoroutine(activeRoutine);
            activeRoutine = null;
        }

        if (Efeito != null) Efeito.SetActive(false);
    }

    IEnumerator FearRoutine()
    {
        if (Efeito != null)
            Efeito.SetActive(true);

        float timer = 0f;

        while (timer < duration && isActive)
        {
            rb.AddForce(transform.forward * boostForce, ForceMode.Acceleration);
            timer += Time.deltaTime;
            yield return null; 
        }

        isActive = false; 
        if (Efeito != null) Efeito.SetActive(false);
        Debug.Log("Fear routine finished/stopped");
    }
}
