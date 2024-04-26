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

        public void TakeDamage(int amount)
        {
            if (isDead)
                return;
            currentHealth -= amount;
            if(currentHealth < 0)
            {
                currentHealth = 0;
                isDead = true;
                OnDeathEvent?.Invoke();
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