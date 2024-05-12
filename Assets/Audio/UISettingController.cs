using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public GameObject soundPanel;
   
    private void Start()
    {
       
        
        CloseMenu();
    }
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

    public void OpenMenu()
    {
       
        Time.timeScale = 0;
        soundPanel.SetActive(true);
        
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        soundPanel.SetActive(false);
        
    }
}
