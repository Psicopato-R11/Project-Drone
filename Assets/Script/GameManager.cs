using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi;
    public GameObject PlayerUi;
    public GameObject MenuUi;
    public static GameManager Instance;
    public static GameManager Instance2;

    void Awake()
    {
        // Set the reference when the game starts
        Instance = this;
        Instance2 = this;
    }

    public void GameOver()
    {
        gameOverUi.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowHUD()
    {
        PlayerUi.SetActive(true);
        MenuUi.SetActive(false);

    }
}
