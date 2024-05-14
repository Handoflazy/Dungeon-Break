using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingMenuManager : MonoBehaviour
{
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;
    [SerializeField]
    private VolumeSO volumeData;

    private void Start()
    {
        masterVol.value = volumeData.MasterVolume;
        musicVol.value = volumeData.MusicVolume;
        sfxVol.value = volumeData.SFXVolume;
        mainAudioMixer.SetFloat("Master Volume", volumeData.MasterVolume);
        mainAudioMixer.SetFloat("Music Volume", volumeData.MusicVolume);
        mainAudioMixer.SetFloat("SFX Volume", volumeData.SFXVolume);
    }


    public void ChangeMasterVolume(float value)
    {
        mainAudioMixer.SetFloat("Master Volume",value);
        volumeData.MasterVolume = value;
    }
    public void ChangeMusicVolume(float value)
    {
        mainAudioMixer.SetFloat("Music Volume", value);
        volumeData.MusicVolume = value;
    }
    public void ChangeSFXVolume(float value)
    {
        mainAudioMixer.SetFloat("SFX Volume", value);
        volumeData.SFXVolume = value;
    }

}
