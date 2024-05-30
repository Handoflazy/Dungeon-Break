using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject ExitBackground, SettingPanel;


    private void Start()
    {
        if (SettingPanel.activeSelf)
        {
            ToggleMenu();
        }
    }
    public void ToggleMenu()
    {
        if (SettingPanel.activeSelf)
        {
            NguyenSingleton.Instance.playerID.playerEvents.OnMenuClose?.Invoke();
            SettingPanel.SetActive(false);
            ExitBackground.SetActive(false);
        }
        else
        {
            NguyenSingleton.Instance.playerID.playerEvents.OnMenuOpen?.Invoke();
            ExitBackground.SetActive(true);
            SettingPanel.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        NguyenSingleton.Instance.playerID.playerEvents.OnMenuClose?.Invoke();
        SettingPanel.SetActive(false);
        ExitBackground.SetActive(false);
    }
    public void OpenMenu() 
    {
        NguyenSingleton.Instance.playerID.playerEvents.OnMenuOpen?.Invoke();
        ExitBackground.SetActive(true);
        SettingPanel.SetActive(true);
    }
}
