/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsLogic : EnemyAIBrain
{
    Player playerScript;
    void Start()
    {
        playerScript = Target.GetComponent<Player>();
        UpdateStatsByPlayer();
    }

    private void UpdateStatsByPlayer()
    {
        if (!Target && !gameObject.CompareTag("BossForest") && !gameObject.CompareTag("BossGrave"))
        {
            statsData.minXpBonus += Mathf.Max(0, playerScript.playerStats.level * (playerScript.playerStats.xp / playerScript.playerStats.levelUpXpRequire) / playerScript.playerStats.xp);
            statsData.maxXpBonus += Mathf.Max(0, playerScript.playerStats.level * (playerScript.playerStats.xp / playerScript.playerStats.levelUpXpRequire) / playerScript.playerStats.xp);
            statsData.damage += playerScript.playerStats.level/10;
            statsData.hp += playerScript.playerStats.level/5;
        }
    }
}
*/