using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUBManagement : MonoBehaviour
{
    public PlayerID playerID;

    public IntEvent UpdateHealthBar;
    public IntEvent UpdateDurationBar;

    public IntEvent OnInitialHealthBar;
    public IntEvent OnInitialDurationBar;


    private void OnEnable()
    {
        playerID.playerEvents.OnHealthChanged += UpdateHealth;
        playerID.playerEvents.OnDurationChanged += UpdateDuration;
        //playerID.playerEvents.onDeath += DisplayGameOver;
        //playerID.playerEvents.onRespawn += HideGameOver;
    }
    private void OnDisable()    
    {
        playerID.playerEvents.OnHealthChanged -= UpdateHealth;
        playerID.playerEvents.OnDurationChanged -= UpdateDuration;
        //playerID.playerEvents.onDeath -= DisplayGameOver;
        //playerID.playerEvents.onRespawn -= HideGameOver;
    }
    private void Awake()
    {
        OnInitialHealthBar?.Invoke(playerID.maxHealth); 
        OnInitialDurationBar?.Invoke(playerID.maxDuration); 
    }


    public void UpdateHealth(int health)
    {
       UpdateHealthBar?.Invoke(health);
    }
    public void UpdateDuration(int duration)
    {
        UpdateDurationBar?.Invoke(duration);
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
