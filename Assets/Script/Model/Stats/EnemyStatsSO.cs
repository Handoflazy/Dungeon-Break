using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Enemy Stats", menuName ="Data/Create Enemy Stats")]
public class EnemyStatsSO : ActorStats
{
    [Header("Xp Bonus")]
    public int minXpBonus;
    public int maxXpBonus;

    [Header("Level Up")]
    public int hpUp;
    public int damageUp;

}
