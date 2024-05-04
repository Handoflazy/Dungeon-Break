using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

using UnityEngine;
using GreenLeaf;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Data/Create Player Stats")]
public class PlayerStatsSO : ActorStats
{
    [Header("Level Up Base:")]
    public int level = 1;
    public int Maxlevel = 100;

    public int xp =0;
    public int levelUpXpRequire;

    [Header("Level Up:")]

    public int levelUpXpRequireUp = 20;
    public int hpUp;
    public int durationUp;
    public int damageUp;
    public int moveSpeedUp;

    //public Transform transformPlayer;
    
    public override bool IsMaxLevel()
    {
        return level >= Maxlevel;
    }


    /*public override void load()
    {
        if (!string.IsNullOrEmpty(Prefs.playerData))
        {
            JsonUtility.FromJsonOverwrite(Prefs.playerData,this);
        }
    }

    public override void Save()
    {
        Prefs.playerData = JsonUtility.ToJson(this);
    }*/
    public void NewGame()
    {
        if (!PlayerPrefs.HasKey("lv")) { level = 1; level++; };
        if (!PlayerPrefs.HasKey("xp")) { xp = 0; };
        if (!PlayerPrefs.HasKey("hp")) { hp = 500; };
    }
    public override void Save()
    {
        AdvancedPlayerPrefs.SetInt("hP", hp);
        AdvancedPlayerPrefs.SetInt("duration", duration);
        AdvancedPlayerPrefs.SetInt("damage", damage);
        AdvancedPlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        AdvancedPlayerPrefs.SetFloat("knockForce", knockForce);
        AdvancedPlayerPrefs.SetInt("lv", level);
        AdvancedPlayerPrefs.SetInt("xp", xp);
        //AdvancedPlayerPrefs.SetTransform("transformPlayer", transformPlayer);
    }
    public override void load()
    {
        AdvancedPlayerPrefs.GetInt("hP", hp);
        AdvancedPlayerPrefs.GetInt("duration", duration);
        AdvancedPlayerPrefs.GetInt("damage", damage);
        AdvancedPlayerPrefs.GetFloat("moveSpeed", moveSpeed);
        AdvancedPlayerPrefs.GetFloat("knockForce", knockForce);
        AdvancedPlayerPrefs.GetInt("lv", level);
        AdvancedPlayerPrefs.GetInt("xp", xp);

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
            moveSpeed += moveSpeedUp * (level / 2 - 0.8f) * 0.2f;

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
