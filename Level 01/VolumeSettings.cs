using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer Mymixer;
    [SerializeField] private AudioSource Mysource;
    [SerializeField] private Slider Slidermusic;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicValue();
        }
    }
    public void SetMusicValue()
    {
        float volume = Slidermusic.value;
        Mymixer.SetFloat("Music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void Mute()
    {
        Slidermusic.value=0;
    }
    public void LoadVolume()
    {
        Slidermusic.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicValue();

    }
}
