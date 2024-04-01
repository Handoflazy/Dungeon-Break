using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private HeartBar healthBar;

    public int MaxHealth { get; private set; }
    public int CurrentHealth;
    public bool IsFull { get; private set; }
    public void InitialHealth(int maxHealh)
    {
        MaxHealth = maxHealh;
        CurrentHealth = maxHealh;
        IsFull = true;
        healthBar.SetMaxHearth(maxHealh);
    }
    public void TakeDame(int dameAmount)
    {
        CurrentHealth -= dameAmount;
        if(CurrentHealth < 0)
            CurrentHealth = 0;
        healthBar.SetHealth(CurrentHealth);
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
        healthBar.SetHealth(CurrentHealth);

    }
}
