using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SunnyValleyVersion;

namespace SunnyValleyVersion
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

        public void TakeDamage(int amount, GameObject sender)
        {
            if (isDead)
                return;
            if (sender.layer == gameObject.layer)
                return;

            currentHealth -= amount;
            if (currentHealth > 0)
            {
                OnHitWithReference?.Invoke(sender);
            }
            else
            {
                OnDeathWithReference?.Invoke(sender);
                isDead = true;
                OnDeathEvent?.Invoke();
            }
            OnHealthChange?.Invoke(currentHealth);
        }
    }
}