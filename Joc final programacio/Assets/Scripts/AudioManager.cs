using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
              if (PlayerPrefs.HasKey("musicVolume"))
        {
                MusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            MusicVolume(50);
        }
    }
    private void Start()
    {
        PlayMusic("DannyTheme");
    }
    public void PlayMusic(string name)
    {
        Sound s  = Array.Find(musicSounds, x => x.name == name);
        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }    public void PlaySFX(string name)
    {
        Sound s  = Array.Find(sfxSounds, x => x.name == name);
        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else{
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume; 

    }

}
