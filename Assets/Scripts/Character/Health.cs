using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SunnyValleyVersion;

namespace FirstVersion
{

    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int currentHealth, maxHealth;

        public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
        public UnityEvent OnDeathEvent;

        public UnityEvent<int> OnHealthChange;
        public UnityEvent<int> OnInitalHealthBar;

        [SerializeField]
        private bool isDead = false;

        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

        private void Start()
        {
            InitializeHealth(maxHealth);
        }
        public void InitializeHealth(int healthValue)
        {
            currentHealth = healthValue;
            maxHealth = healthValue;
            OnInitalHealthBar?.Invoke(healthValue);
            isDead = false;
        }

        public void TakeDamage(int amount, GameObject sender)
        {    
            if(sender.layer == gameObject.layer)
            {
                return;
            }
            if (isDead)
                return;
            currentHealth -= amount;
            if(currentHealth < 0)
            {
                currentHealth = 0;
                isDead = true;
                OnDeathEvent?.Invoke();
                OnDeathWithReference?.Invoke(sender);
            }
            OnHealthChange?.Invoke(currentHealth);
        }

        public void AddHealth(int amount)
        {
            if(currentHealth >= maxHealth)
            {
                return;
            }
            currentHealth += amount;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            OnHealthChange?.Invoke(currentHealth);
        }
    }
}