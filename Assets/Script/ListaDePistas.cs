using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPista : MonoBehaviour
{
    public void Fog ()
    {
        SceneManager.LoadScene("FogRealm");
    }

    public void Lava ()
    {
        SceneManager.LoadScene("Lava");
    }

    public void Swamp ()
    {
        SceneManager.LoadScene("SwampRealm");
    }

    public void Water ()
    {
        SceneManager.LoadScene("WaterRealm");
    }

    public void Tutorial ()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Fear ()
    {
        SceneManager.LoadScene("Fear");
    }

    public void Ruins()
    {
        SceneManager.LoadScene("RuinsRealm");
    }

    public void Storm()
    {
        SceneManager.LoadScene("StormRealm");
    }

    public void Time()
    {
        SceneManager.LoadScene("TimeRealm");
    }

    public void Junk()
    {
        SceneManager.LoadScene("JunkRealm");
    }

    public void Metro()
    {
        SceneManager.LoadScene("MetroRealm");
    }

    public void Cosmic()
    {
        SceneManager.LoadScene("CosmicRealm");
    }

    public void Wind()
    {
        SceneManager.LoadScene("WindRealm");
    }

    public void Rain()
    {
        SceneManager.LoadScene("RainRealm");
    }

    public void Sky()
    {
        SceneManager.LoadScene("SkyRealm");
    }

    public void Sair ()
    {
        SceneManager.LoadScene("Menu");
    }
}
