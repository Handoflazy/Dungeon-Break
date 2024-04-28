using System;
using UnityEngine;

public abstract class StatsSO : ScriptableObject
{
    public abstract void Save();
    public abstract void load();

    public abstract void Upgrade(Action OnSuccess = null, Action Failled = null);

    public abstract bool IsMaxLevel();
}
