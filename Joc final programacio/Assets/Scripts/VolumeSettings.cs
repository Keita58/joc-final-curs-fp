using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
 // [SerializeField] private AudioMixer mixer;
  [SerializeField] private Slider musicSlider;
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
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        //mixer.SetFloat("music", Mathf.Log10(volume)*20);
        //AudioManager.Instance.
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
}
