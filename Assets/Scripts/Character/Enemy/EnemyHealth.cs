using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstVersion;
public class EnemyHealth : Health
{
    EnemyReform enemyController;
    private void Awake()
    {
        enemyController = GetComponent<EnemyReform>();
        MaxHealth = enemyController.statsData.hp;
    }
}
