using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
        
        PlayerPrefs.Save();
    }
}
