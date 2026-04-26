using System.Collections;
using UnityEngine;

public class FogActivate : MonoBehaviour
{
    [Header("Fog Settings")]
    public float targetDensity = 0.05f; // Densidade final da neblina
    public float transitionSpeed = 0.5f; // Velocidade da transição
    public Color fogColor = Color.gray; // Cor da neblina

    private bool isTransitioning = false;
    private float originalDensity;
    private Color originalColor;

    private void Start()
    {
        // Guarda o estado original do fog
        originalDensity = RenderSettings.fogDensity;
        originalColor = RenderSettings.fogColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeFog(true));
            Debug.Log("Entrou na área de neblina");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeFog(false));
            Debug.Log("Saiu da área de neblina");
        }
    }

    private IEnumerator ChangeFog(bool enable)
    {
        isTransitioning = true;

        float startDensity = RenderSettings.fogDensity;
        float endDensity = enable ? targetDensity : 0f;
        Color startColor = RenderSettings.fogColor;
        Color endColor = enable ? fogColor : originalColor;

        if (enable)
            RenderSettings.fog = true; // garante que liga o fog ao entrar

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;
            RenderSettings.fogDensity = Mathf.Lerp(startDensity, endDensity, t);
            RenderSettings.fogColor = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        RenderSettings.fogDensity = endDensity;
        RenderSettings.fogColor = endColor;

        // Se a densidade final for quase zero, desativa totalmente
        if (!enable)
            RenderSettings.fog = false;

        isTransitioning = false;
    }
}
