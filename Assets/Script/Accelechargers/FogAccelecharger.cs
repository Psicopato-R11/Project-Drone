using UnityEngine;
using System.Collections;
using System;

public class FogAccelecharger : MonoBehaviour, IAccelecharger
{
    [Header("Fog Config")]
    public Color effectColor = Color.yellow;
    public float duration = 15f;
    public float fadeTime = 2f;
    public float clearedDensity = 0f;

    private bool used = false;
    private bool isActive = false;
    private float originalDensity; 
    private Coroutine fogRoutineInstance;
    public bool IsActive => isActive;
    public Color EffectColor => effectColor;
    public float Duration => duration;

    void Start()
    {
        originalDensity = RenderSettings.fogDensity;
    }

    public void Activate()
    {
        if (used) return;
        used = true;
        isActive = true;

        fogRoutineInstance = StartCoroutine(FogRoutine());
    }

    public void Deactivate()
    {
        if (!isActive) return;
        isActive = false;

        if (fogRoutineInstance != null)
        {
            StopCoroutine(fogRoutineInstance);
            StartCoroutine(FadeFog(RenderSettings.fogDensity, originalDensity, fadeTime));
        }
    }

    public void StopWait()
    {
        Deactivate();
    }

    IEnumerator FogRoutine()
    {
        RenderSettings.fog = true;

        yield return StartCoroutine(FadeFog(originalDensity, clearedDensity, fadeTime));

        yield return new WaitForSeconds(duration);

        yield return StartCoroutine(FadeFog(clearedDensity, originalDensity, fadeTime));

        isActive = false;
        fogRoutineInstance = null;
    }

    IEnumerator FadeFog(float from, float to, float time)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time;
            RenderSettings.fogDensity = Mathf.Lerp(from, to, t);
            yield return null;
        }
        RenderSettings.fogDensity = to;
    }
}
