using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : PlayerSystem
{

   
    public int MaxHealth { get; private set; }
    public int CurrentHealth {  get; private set; }
    public UnityEvent OnHealthAtZero;
    private void OnEnable()
    {
        player.ID.playerEvents.onTakeDamage += TakeDame;
        player.ID.playerEvents.OnHeal += Heal;
        player.ID.playerEvents.onRespawn += InitialHealth;
    }

    protected override void Awake()
    {
        base.Awake();
        if (player == null)
        {
            print(null);
        }
        MaxHealth = player.ID.maxHealth;
    }
    private void OnDisable()
    {
        player.ID.playerEvents.onTakeDamage -= TakeDame;
        player.ID.playerEvents.OnHeal -= Heal;
        player.ID.playerEvents.onRespawn -= InitialHealth;
    }
    public void InitialHealth()
    {
        MaxHealth = player.ID.maxHealth;
        CurrentHealth = MaxHealth;
        player.ID.playerEvents.OnHealthChanged?.Invoke(CurrentHealth);
    }
    public void TakeDame(int dameAmount)
    {
        CurrentHealth -= dameAmount;
        
        if (CurrentHealth <= 0)
        {
            player.ID.playerEvents.onDeath?.Invoke();
            OnHealthAtZero?.Invoke();
            CurrentHealth = 0;
        }
        player.ID.playerEvents.OnHealthChanged?.Invoke(CurrentHealth);

    }
    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        player.ID.playerEvents.OnHealthChanged?.Invoke(CurrentHealth);
    }
}

