using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private GameObject UR_Manager;
    
    void Start()
    {
        UR_Manager = GameObject.Find("UR_Manager");
        
    }

    public void Play ()
    {
        Destroy(UR_Manager);
        SceneManager.LoadScene("ListaDePistas");
    }

    public void QG()
    {
        Destroy(UR_Manager);
        SceneManager.LoadScene("QG");
    }

    public void QuitGame ()
    {
        Debug.Log ("O player saiu do jogo.");
        Application.Quit();
    }

    public void ChangeCar ()
    {
        Destroy(UR_Manager);
        SceneManager.LoadScene("CarSelecion");
    }

    public void ChangeAccelecharger()
    {
        Destroy(UR_Manager);
        SceneManager.LoadScene("AccelechargerSelection"); 
    }
}
