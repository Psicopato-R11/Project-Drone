using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccelechargerHandler : MonoBehaviour
{
    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip startClip;
    public AudioClip loopClip;
    public AudioClip endClip;

    private IAccelecharger current;
    public bool used = false;

    private Renderer[] renderers;
    private List<Material[]> originalMaterials = new List<Material[]>();
    private bool isActive = false;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            originalMaterials.Add(r.materials);
        }

        int equipped = PlayerPrefs.GetInt("EquippedAccelecharger", -1);

        if (equipped == -1) return;

        IAccelecharger[] accelechargers = GetComponents<IAccelecharger>();

        if (equipped < accelechargers.Length)
        {
            current = accelechargers[equipped];
        }

        UpdateInterfaceVisuals();
    }

    void Update()
    {
        if (current == null) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (current.IsActive)
            {
                current.Deactivate();
                used = true;
                isActive = false;
                RestoreOriginalMaterials();
                UpdateInterfaceVisuals();
                StopLoopSound();
                PlayEndSound();
            }
            else if (!used)
            {
                PlayStartSound();
                isActive = true;
                current.Activate();
                StartCoroutine(ApplyColorEffect(current));
                UpdateInterfaceVisuals();

            }
        }
    }

    IEnumerator ApplyColorEffect(IAccelecharger acc)
    {
        ApplyColor(acc.EffectColor);

        yield return new WaitForSeconds(acc.Duration);

        if (isActive)
        {
            isActive = false;
            StopLoopSound();
            PlayEndSound();
        }

        isActive = false;
        used = true;
        UpdateInterfaceVisuals();
        RestoreOriginalMaterials();
    }

    void ApplyColor(Color color)
    {
        foreach (Renderer r in renderers)
        {
            Material[] mats = r.materials;
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = new Material(mats[i]);
                mats[i].EnableKeyword("_EMISSION");
                mats[i].SetColor("_EmissionColor", color);
                mats[i].SetColor("_BaseColor", color);
            }
            r.materials = mats;
        }
    }

    void RestoreOriginalMaterials()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].materials = originalMaterials[i];
        }
    }

    void UpdateInterfaceVisuals()
    {
        if (current == null) return;

        (Color corFinal, string statusTexto) = (isActive, used) switch
        {
            
            (false, true) => (Color.red, "USADO"),
            (true, _) => (Color.white, "ATIVO"),
            (false, false) => (Color.green, "DISPONÍVEL"),
        };

        // Dispara para quem estiver ouvindo (a UI)
        AccelechargerEvents.TriggerStatusUpdate(corFinal, statusTexto);
    }

    void PlayStartSound()
    {
        audioSource.loop = false;
        audioSource.clip = startClip;
        audioSource.Play();

        StartCoroutine(StartLoopAfterClip(startClip.length));
    }

    IEnumerator StartLoopAfterClip(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (isActive)
        {
            audioSource.loop = true;
            audioSource.clip = loopClip;
            audioSource.Play();
        }
    }

    void StopLoopSound()
    {
        audioSource.Stop();
    }

    void PlayEndSound()
    {
        audioSource.loop = false;
        audioSource.clip = endClip;
        audioSource.Play();
    }
}