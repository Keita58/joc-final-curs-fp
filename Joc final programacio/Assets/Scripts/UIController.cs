using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{    public Slider musicSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }
    public void ToggleMusic()
    {
        //AudioManager.Instance.ToggleMusic();
    }
    public void SetMusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
}
