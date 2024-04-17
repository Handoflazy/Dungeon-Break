using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUBManagement : MonoBehaviour
{
    public PlayerID playerID;
    [SerializeField] private SliderBar healthBar;
    [SerializeField] private SliderBar durationBar;

    private void OnEnable()
    {
        playerID.playerEvents.OnDurationChanged += OnDurationChanged;
        playerID.playerEvents.onInitialDuration += InitialMaxValueDurationBar;
    }
    private void OnDisable()    
    {
        playerID.playerEvents.OnDurationChanged -= OnDurationChanged;
        playerID.playerEvents.onInitialDuration -= InitialMaxValueDurationBar;
    }
    private void Awake()
    {
        healthBar = transform.GetChild(0).GetComponent<SliderBar>();
        durationBar = transform.GetChild(1).GetComponent<SliderBar>();

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



    //public void DisplayGameOver()
    //{
    //    gameOverPanel.gameObject.SetActive(true);
    //}
    //public void HideGameOver()
    //{
    //    gameOverPanel.gameObject.SetActive(false);
    //}
}
