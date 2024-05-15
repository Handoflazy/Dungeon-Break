using InventoryVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstVersion;
using UnityEngine.Events;


public class HealthBoss : FirstVersion.Health
{
    public UnityEvent<int> OnInitialBossBar;
    EnemyAIBrain enemyController;
    public void InitialBossBar()
    {
        OnInitialBossBar?.Invoke(MaxHealth);  
    }
    private void Awake()
    {
        enemyController = GetComponent<EnemyAIBrain>();
        MaxHealth = enemyController.statsData.hp;
        CurrentHealth = enemyController.statsData.hp;
    }
}
