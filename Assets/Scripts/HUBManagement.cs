using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HUBManagement : MonoBehaviour
{
    public PlayerID playerID;
    [SerializeField] private SliderBar healthBar;
    [SerializeField] private SliderBar durationBar;

    [SerializeField] private UIAmmo uiAmmo;

    [SerializeField] GameObject deathMenu;

    private void Awake()
    {
        uiAmmo = GetComponentInChildren<UIAmmo>();
    }
    private void OnEnable()
    {
        playerID.playerEvents.onRespawn += HideGameOver;
        playerID.playerEvents.OnDurationChanged += OnDurationChanged;
        playerID.playerEvents.onInitialDuration += InitialMaxValueDurationBar;
        playerID.playerEvents.UpdateAmmo += uiAmmo.UpdateBulletsText;
    }
    private void OnDisable()    
    {
        playerID.playerEvents.onRespawn -= HideGameOver;
        playerID.playerEvents.OnDurationChanged -= OnDurationChanged;
        playerID.playerEvents.onInitialDuration -= InitialMaxValueDurationBar;
        playerID.playerEvents.UpdateAmmo -= uiAmmo.UpdateBulletsText;
    }
    public void InitialMaxValueHealthBar(int maxHealth)
    {
       healthBar.SetMaxValue(maxHealth);
    }
    public void InitialMaxValueDurationBar(int maxDuration)
    {
        durationBar.SetMaxValue(maxDuration);
    }

    public void OnHealthChanged(int currentHealth)
    {
        healthBar.SetValue(currentHealth);
    }
    public void OnDurationChanged(int currentDuration)
    {
        durationBar.SetValue(currentDuration);
    }



    public void DisplayGameOver()
    {
        deathMenu.SetActive(true);
    }
    public void HideGameOver()
    {
        deathMenu.SetActive(false);
    }
}
