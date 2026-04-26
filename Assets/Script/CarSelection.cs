using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Carros")]
    public GameObject[] cars;

    [Header("UI")]
    public Button next;
    public Button prev;
    public Button chooseButton;
    public TextMeshProUGUI statusText;

    int index;

    void Start()
    {
        // EXEMPLO DE UNLOCK (remova depois)
        PlayerPrefs.SetInt("Car_RD_06", 1);
        PlayerPrefs.Save();

        index = PlayerPrefs.GetInt("carIndex", 0);

        // garante que começa em um carro desbloqueado
        if (PlayerPrefs.GetInt(GetKey(index), 0) == 0)
            index = FindFirstUnlocked();

        Debug.Log("RD-06 Lava: " + PlayerPrefs.GetInt("Car_RD_06_Lava", 0)); Debug.Log("RD-08: " + PlayerPrefs.GetInt("Car_RD_08", 0)); Debug.Log("RD-02: " + PlayerPrefs.GetInt("Car_RD_02", 0)); Debug.Log("RD-12: " + PlayerPrefs.GetInt("Car_RD_12", 0)); Debug.Log("Drone: " + PlayerPrefs.GetInt("Car_Drone", 0)); Debug.Log("RoloCompressor: " + PlayerPrefs.GetInt("Car_Drone", 0)); Debug.Log("RD-09: " + PlayerPrefs.GetInt("Car_RD_09", 0)); Debug.Log("RD-07: " + PlayerPrefs.GetInt("Car_RD_07", 0)); Debug.Log("Strange Car: " + PlayerPrefs.GetInt("Car_Strange_Car", 0)); Debug.Log("RD-06 Acceleron: " + PlayerPrefs.GetInt("Car_RD_06_Acceleron", 0)); Debug.Log("RD-08 Acceleron: " + PlayerPrefs.GetInt("Car_RD_08_Acceleron", 0)); Debug.Log("RD-02 Acceleron: " + PlayerPrefs.GetInt("Car_RD_02_Acceleron", 0)); Debug.Log("RD-12 Acceleron: " + PlayerPrefs.GetInt("Car_RD_12_Acceleron", 0)); Debug.Log("RD-09 Acceleron: " + PlayerPrefs.GetInt("Car_RD_09_Acceleron", 0));
        Debug.Log("Tentando ler a chave: " + GetKey(9));
        ShowCar();
        UpdateUI();
    }

    void Update()
    {
        UpdateNavigationButtons();
    }

    // =========================
    // CHAVES
    // =========================
    string GetKey(int index)
    {
        return "Car_" + ((CarUnlock.CarType)index).ToString();
    }

    // =========================
    // UI
    // =========================
    void UpdateUI()
    {
        bool unlocked = PlayerPrefs.GetInt(GetKey(index), 0) == 1;

        chooseButton.interactable = unlocked;
        statusText.text = unlocked ? "Desbloqueado" : "Bloqueado";
    }

    void UpdateNavigationButtons()
    {
        next.interactable = HasUnlockedNext();
        prev.interactable = HasUnlockedPrev();
    }

    // =========================
    // NAVEGAÇÃO
    // =========================
    public void Next()
    {
        index = FindNextUnlocked(index);
        SaveAndShow();
    }

    public void Prev()
    {
        index = FindPrevUnlocked(index);
        SaveAndShow();
    }

    int FindNextUnlocked(int start)
    {
        int i = start;

        do
        {
            i++;
            if (i >= cars.Length)
                i = 0;

            if (PlayerPrefs.GetInt(GetKey(i), 0) == 1)
                return i;

        } while (i != start);

        return start;
    }

    int FindPrevUnlocked(int start)
    {
        int i = start;

        do
        {
            i--;
            if (i < 0)
                i = cars.Length - 1;

            if (PlayerPrefs.GetInt(GetKey(i), 0) == 1)
                return i;

        } while (i != start);

        return start;
    }

    bool HasUnlockedNext()
    {
        return FindNextUnlocked(index) != index;
    }

    bool HasUnlockedPrev()
    {
        return FindPrevUnlocked(index) != index;
    }

    int FindFirstUnlocked()
    {
        for (int i = 0; i < cars.Length; i++)
            if (PlayerPrefs.GetInt(GetKey(i), 0) == 1)
                return i;

        return 0;
    }

    // =========================
    // CARRO
    // =========================
    void ShowCar()
    {
        for (int i = 0; i < cars.Length; i++)
            cars[i].SetActive(false);

        cars[index].SetActive(true);
    }

    void SaveAndShow()
    {
        ShowCar();
        UpdateUI();
        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    // =========================
    // AÇÃO
    // =========================
    public void Race()
    {
        PlayerPrefs.SetInt("EquippedCar", index);
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("Menu");
    }
}
