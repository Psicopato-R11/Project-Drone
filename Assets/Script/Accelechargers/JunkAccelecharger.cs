using UnityEngine;
using System.Collections;

public class JunkAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Junk configs")]
    public float duration = 7.5f;
    public Color effectColor = Color.yellow;

    public GameObject Efeitos;
    public float boostForce;
    public float delay;

    private Rigidbody rb;
    private Coroutine activeRoutine;
    private bool used = false;
    
    private bool isActive = false;
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Efeitos.SetActive(false);
    }
    
    public void Activate()
    {
        if (used) return;
        Debug.Log("Cosmic ativado");
        used = true;
        isActive = true;
        activeRoutine = StartCoroutine(JunkCoroutine());
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



    IEnumerator JunkCoroutine()
    {
        int boosts = 0;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
        }
       

        while (boosts < 3)
        {
            if (Efeitos != null)
            Efeitos.SetActive(true);

            rb.AddForce(transform.forward * boostForce, ForceMode.VelocityChange);
            boosts++;
            yield return new WaitForSeconds(delay);

            if (Efeitos != null) Efeitos.SetActive(false);
        }

        isActive = false;
        
        Debug.Log("Junk coroutine stopped or finished.");
    }
}
