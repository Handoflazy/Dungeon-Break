using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public GameObject soundPanel, pausepanel;

    public void TogglerMusic()
    {
        NguyenSingleton.Instance.AudioManager.ToggleMusic();
    }
    public void TogglerSFX()
    {
        NguyenSingleton.Instance.AudioManager.ToggleSFX();
    }
    public void MusicVolume()
    {
        NguyenSingleton.Instance.AudioManager.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        NguyenSingleton.Instance.AudioManager.SFXVolume(_sfxSlider.value);
    }

    public void SoundSystem()
    {
        Time.timeScale = 0;
        soundPanel.SetActive(true);
        pausepanel.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
    }
    public void Cancel()
    {
        pausepanel.SetActive(true);
        soundPanel.SetActive(false);
    }
    public void CancelHome()
    {
        soundPanel.SetActive(false);
    }
    public void PauseSystem()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }
}
