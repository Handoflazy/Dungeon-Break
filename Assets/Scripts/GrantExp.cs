using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantExp : MonoBehaviour
{
    private EnemyAIBrain enemy;
    private void Awake()
    {
        enemy = GetComponent<EnemyAIBrain>();
    }
    public void GiveExp(GameObject character)
    {
        GameObject player = GameObject.Find("Player");
        if (player.TryGetComponent<StatsManagerSystem>(out StatsManagerSystem playerStatsSystem))
        {                  
            int exp = Random.Range(enemy.statsData.minXpBonus, enemy.statsData.maxXpBonus);
            playerStatsSystem.AddXp(exp);
            DGSingleton.Instance.FloatingTextManager.Show("+ " + exp, 30, Color.blue, transform.position, Vector3.up, .7f);
            
        }

    }
}
