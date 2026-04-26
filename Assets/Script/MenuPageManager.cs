using UnityEngine;

public class MenuPageManager : MonoBehaviour
{
    [Header("Páginas do menu (arraste aqui no Inspector)")]
    public GameObject[] pages;
    private int currentPage = 0;

    void Start()
    {
        ShowPage(currentPage);
    }

    public void NextPage()
    {
        currentPage++;
        if (currentPage >= pages.Length)
            currentPage = 0; // ou use "pages.Length - 1" pra travar no fim
        ShowPage(currentPage);
    }

    public void PreviousPage()
    {
        currentPage--;
        if (currentPage < 0)
            currentPage = pages.Length - 1; // ou "0" pra travar no início
        ShowPage(currentPage);
    }

    private void ShowPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == index);
        }
    }
}
