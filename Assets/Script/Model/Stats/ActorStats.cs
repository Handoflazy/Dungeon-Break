using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : StatsSO
{
    [Header("Base Stats:")]
    public int hp;
    public int duration;
    public int damage;
    public float moveSpeed;
    public float knockForce;
    public override bool IsMaxLevel()
    {
        return false;
    }

    public override void load()
    {
        
    }

    public override void Save()
    {
       
    }

    public override void Upgrade(Action OnSuccess = null, Action Failled = null)
    {
       
    }
}
