using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstVersion;

public class EnemyHealth : Health
{
    EnemyAIBrain enemyController;
    private void Awake()
    {
        enemyController = GetComponent<EnemyAIBrain>();
        MaxHealth = enemyController.statsData.hp;
    }
}
