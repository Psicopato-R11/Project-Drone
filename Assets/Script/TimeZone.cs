using System.Collections;
using UnityEngine;

public class TimeZone : MonoBehaviour
{
    public enum TimeEffect { Slow, Fast }

    [Header("Configuração da zona de tempo")]
    public TimeEffect effect = TimeEffect.Slow;
    public float slowScale = 0.5f;
    public float fastScale = 1.5f;
    public float transitionSpeed = 2f;
    [Header("Som")]
    public AudioSource timeBell;

    private Coroutine currentRoutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentRoutine != null)
                StopCoroutine(currentRoutine);
            currentRoutine = StartCoroutine(ApplyTimeEffect());
        }
        timeBell.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentRoutine != null)
                StopCoroutine(currentRoutine);
            currentRoutine = StartCoroutine(ResetTimeEffect());
        }
        timeBell.Play();
    }

    private IEnumerator ApplyTimeEffect()
    {
        float target = (effect == TimeEffect.Slow) ? slowScale : fastScale;

        while (Mathf.Abs(Time.timeScale - target) > 0.01f)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, target, Time.unscaledDeltaTime * transitionSpeed);
            Time.fixedDeltaTime = 0.02f * Time.timeScale; // ajusta a física pro novo timeScale
            yield return null;
        }
        Time.timeScale = target;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    private IEnumerator ResetTimeEffect()
    {
        while (Mathf.Abs(Time.timeScale - 1f) > 0.01f)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * transitionSpeed);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            yield return null;
        }
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
