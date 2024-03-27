using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsFull { get; private set; }
    public void InitialHealth(int maxHealh)
    {
        MaxHealth = maxHealh;
        CurrentHealth = maxHealh;
        IsFull = true;
    }
    public void TakeDame(int dameAmount)
    {
        CurrentHealth -= dameAmount;
        if(CurrentHealth < 0)
            CurrentHealth = 0;
        IsFull=false;
    }
    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            IsFull = true;
        }
    }
}
