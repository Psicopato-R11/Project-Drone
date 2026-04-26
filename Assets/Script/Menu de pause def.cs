using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenudePausedef : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public TrackType trackName;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        UltimateRaceManager.Instance.raceTimer = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(trackName.ToString());
        UltimateRaceManager.Instance.raceTimer = 0f;
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }
}