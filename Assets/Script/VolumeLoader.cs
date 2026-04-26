using UnityEngine;
using UnityEngine.UI;

public class VolumeLoader : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("soundVolume");

            AudioListener.volume = savedVolume;
            Debug.Log("Current volume: " + savedVolume);
        }
        else
        {
            AudioListener.volume = 1f;
            PlayerPrefs.SetFloat("soundVolume", 1f);
            PlayerPrefs.Save();
        }
    }
}
