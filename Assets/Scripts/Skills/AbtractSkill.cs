using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbtractSkill : PlayerSystem
{
    public int maxLevel { get; set; }
    public int level { get; set; }

    public bool canUse { get; protected set; }
    [SerializeField]
    protected float[] cooldown = {1,4,3,2,1};
    [SerializeField]
    protected int[] durationCost= { 20, 30, 40, 50, 60 };


    public virtual void OnUsed()
    {
        print("dang su dung");
    }
    public int GetDurationCost()
    {
        return durationCost[level];
    }
    public float GetCowndown()
    {
        return cooldown[level];
    }
}
