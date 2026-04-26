using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenudePausaTime : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continuar7();
            }
            else
            {
                Pausar7();
            }
        }
    }

    public void Continuar7()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pausar7()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void CarregarMenu7()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ReiniciarGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TimeRealm");
    }
}