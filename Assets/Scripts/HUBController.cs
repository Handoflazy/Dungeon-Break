using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HUBController : MonoBehaviour
{
    private PlayerID playerID;
    [SerializeField] private SliderBar healthBar;
    [SerializeField] private SliderBar durationBar;
    [SerializeField] private ItemUI uiAmmo;

    [SerializeField] private Image WeaponImage;

    [SerializeField] GameObject deathMenu;

    [SerializeField] private GameObject HUB;
    private void OnEnable()
    {
        playerID = NguyenSingleton.Instance.PlayerID;
        playerID.playerEvents.OnDialogueStart += HideHUB;
        playerID.playerEvents.OnDialogueEnd += DisplayHUB;
        playerID.playerEvents.onRespawn += HideGameOver;
        playerID.playerEvents.OnDurationChanged += OnDurationChanged;
        playerID.playerEvents.onInitialDuration += InitialMaxValueDurationBar;
        playerID.playerEvents.OnUpdateAmmo += uiAmmo.UpdateNumberText;
        playerID.playerEvents.OnChangeGun += OnChangeWeaponUI;
    }
    private void OnDisable()
    {
        playerID.playerEvents.OnDialogueStart -= HideHUB;
        playerID.playerEvents.OnDialogueEnd -= DisplayHUB;
        playerID.playerEvents.onRespawn -= HideGameOver;
        playerID.playerEvents.OnDurationChanged -= OnDurationChanged;
        playerID.playerEvents.onInitialDuration -= InitialMaxValueDurationBar;
        playerID.playerEvents.OnUpdateAmmo -= uiAmmo.UpdateNumberText;
        playerID.playerEvents.OnChangeGun -= OnChangeWeaponUI;
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
        currentHealth = PlayerPrefs.GetInt(PrefConsts.CURRENT_HEALTH_KEY);

        healthBar.SetValue(currentHealth);
    }
    public void OnDurationChanged(int currentDuration)
    {
        currentDuration = PlayerPrefs.GetInt(PrefConsts.CURRENT_DURATION_KEY);
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
    public void HideHUB()
    {
        HUB.SetActive(false);
    }
    public void DisplayHUB()
    {   
        HUB.SetActive(true );
    }

    public void ToggleInventoryUI()
    {
        NguyenSingleton.Instance.PlayerID.playerEvents.OnInventoryButtonToggle?.Invoke();
    }

    public void OnChangeWeaponUI(BasicGun newGun)
    {
        if (newGun)
        {
            WeaponImage.sprite = newGun.gameObject.GetComponent<SpriteRenderer>().sprite;
            WeaponImage.enabled = true;
        }
        else
        {
            WeaponImage.enabled = false;
            WeaponImage.sprite = null;
        }
    }
    
}
