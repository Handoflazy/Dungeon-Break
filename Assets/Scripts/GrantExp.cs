using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantExp : MonoBehaviour
{
    private EnemyReform enemy;
    private void Awake()
    {
        enemy = GetComponent<EnemyReform>();
    }
    public void GiveExp(GameObject character)
    {
       
        if (character.TryGetComponent<StatsManagerSystem>(out StatsManagerSystem playerStatsSystem))
        {
            print(character.name);
            int exp = Random.Range(enemy.statsData.minXpBonus, enemy.statsData.maxXpBonus);
            playerStatsSystem.AddXp(exp);
            NguyenSingleton.Instance.FloatingTextManager.Show("+ " + exp, 30, Color.blue, transform.position, Vector3.up, .7f);
            
        }

    }
}
