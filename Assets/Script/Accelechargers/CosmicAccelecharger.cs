using UnityEngine;
using System.Collections;

public class CosmicAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Cosmic Config")]
    public Color effectColor = Color.yellow;
    public GameObject Efeitos;
    public float duration = 15f;
    public float Force = 50f;
    public float downForceMagnitude = 20f;

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
        Debug.Log("Cosmic ativado");
        used = true;
        isActive = true;
        activeRoutine = StartCoroutine(CosmicCoroutine());
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

        if (Efeitos != null) Efeitos.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            rb.AddForce(-transform.up * downForceMagnitude, ForceMode.Force);
        }
        
    }

    IEnumerator CosmicCoroutine()
    {
        if (Efeitos != null)
            Efeitos.SetActive(true);

        float timer = 0f;

        while (timer < duration && isActive)
        {
            rb.AddForce(transform.forward * Force, ForceMode.Acceleration);
            timer += Time.deltaTime;
            yield return null;
        }

        isActive = false;
        if (Efeitos != null) Efeitos.SetActive(false);
        Debug.Log("Cosmic coroutine stopped or finished.");
    }
}
