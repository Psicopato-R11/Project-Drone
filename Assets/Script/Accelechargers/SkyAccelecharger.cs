using UnityEngine;
using System.Collections;

public class SkyAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Sky config")]
    public Color effectColor = Color.yellow;
    public float duration = 30f;
    public GameObject Efeitos;
    public float gravityMultiplier = 0.3f;

    private Rigidbody rb;
    private Coroutine activeRoutine;
    private bool used = false;

    private bool isActive = false;
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    public void Activate()
    {
        if (used) return;
        Debug.Log("Sky ativado");
        used = true;
        isActive = true;
        activeRoutine = StartCoroutine(SkyCoroutine());
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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator SkyCoroutine()
    {
        if (Efeitos != null) Efeitos.SetActive(true);

        float timer = 0f;

        while (timer < duration)
        {
            rb.AddForce(
                Physics.gravity * (gravityMultiplier - 1f),
                ForceMode.Acceleration
            );

            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        isActive = false;
        if (Efeitos != null) Efeitos.SetActive(false);
    }

}
