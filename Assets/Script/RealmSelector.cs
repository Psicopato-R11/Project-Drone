using UnityEngine;
using System.Collections;

public class RealmSelector : MonoBehaviour
{
    public GameObject[] Realms;
    public float transitionTime = 0.35f;

    private int currentIndex = 0;
    private bool isAnimating = false;

    RectTransform currentRT;
    RectTransform nextRT;

    void Start()
    {
        for (int i = 0; i < Realms.Length; i++)
            Realms[i].SetActive(i == 0);

        currentRT = Realms[0].GetComponent<RectTransform>();
    }

    public void MoveDown()
    {
        if (isAnimating) return;
        StartCoroutine(Animate(+1));
    }

    public void MoveUp()
    {
        if (isAnimating) return;
        StartCoroutine(Animate(-1));
    }

    IEnumerator Animate(int dir)
    {
        isAnimating = true;

        int nextIndex = (currentIndex + dir + Realms.Length) % Realms.Length;

        GameObject nextObj = Realms [nextIndex];
        nextObj.SetActive(true);

        nextRT = nextObj.GetComponent<RectTransform>();
        currentRT = Realms[currentIndex].GetComponent<RectTransform>();

        float height = currentRT.rect.height;

        nextRT.anchoredPosition = new Vector2(
            0,
            dir > 0 ? -height : height
        );

        Vector2 currentTarget = new Vector2(
            0,
            dir > 0 ? height : -height
        );

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / transitionTime;
            currentRT.anchoredPosition = Vector2.Lerp(Vector2.zero, currentTarget, t);
            nextRT.anchoredPosition = Vector2.Lerp(nextRT.anchoredPosition, Vector2.zero, t);
            yield return null;
        }

        Realms[currentIndex].SetActive(false);
        currentRT.anchoredPosition = Vector2.zero;

        currentIndex = nextIndex;
        currentRT = nextRT;

        isAnimating = false;
    }
}
