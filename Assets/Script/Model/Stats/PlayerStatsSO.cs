using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Stats", menuName = "Data/Create Player Stats")]
public class PlayerStatsSO : ActorStats
{
    [Header("Level Up Base:")]

    public int Maxlevel;
    [field:SerializeField]
    public int level { get; private set; }
    public int xp;
    public int levelUpXpRequire;

    [Header("Level Up:")]

    public int levelUpXpRequireUp;
    public int hpUp;
    public int durationUp;
    public int damageUp;
    public bool ResetStat;

    public override bool IsMaxLevel()
    {
        return level >= Maxlevel;
    }

    public override void load()
    {
        if (!string.IsNullOrEmpty(Prefs.playerData)&&!ResetStat)
        {
            JsonUtility.FromJsonOverwrite(Prefs.playerData,this);
            
            
        }
    }

    public override void Save()
    {
        Prefs.playerData = JsonUtility.ToJson(this);
    }
    public override void Upgrade(Action OnSuccess = null, Action OnFailled = null)
    {
      
        float upgareFormular = (level / 2 - 0.5f) * 0.5f;
        while (xp >= levelUpXpRequire && !IsMaxLevel())
        {
            Debug.Log("da nang cap");
            level++;
            xp -= levelUpXpRequire;
            levelUpXpRequire += levelUpXpRequireUp;

            hp += (int)(hpUp*upgareFormular);
            damage += (int)(damageUp * upgareFormular);

            duration += (int)(durationUp * upgareFormular);
            Save();
            OnSuccess?.Invoke();
        }
        if(xp  <= levelUpXpRequire && IsMaxLevel())
        {
            OnFailled?.Invoke();
        }
    }
}
