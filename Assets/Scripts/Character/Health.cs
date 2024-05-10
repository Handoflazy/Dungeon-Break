using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SunnyValleyVersion;

namespace FirstVersion
{

    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private bool isDead = false;

        public UnityEvent<GameObject> OnHitWithReference;
        public UnityEvent<GameObject> OnDeathWithReference;
        public UnityEvent OnDeathEvent;
        public UnityEvent<int> OnHealthChange,OnInitalHealthBar;
        public UnityEvent OnHit;


        public bool isFull { get; set; }


        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

        private void Start()
        {
            SetInitializeHealth(maxHealth);
            //LoadHP();
            //OnHealthChange?.Invoke(currentHealth);
            print(currentHealth);
            OnHealthChange?.Invoke(currentHealth);
        }
        public void SetInitializeHealth(int healthValue)
        {
            //currentHealth = healthValue;
            //maxHealth = healthValue;
            OnInitalHealthBar?.Invoke(healthValue);
            isDead = false;
            isFull = true;
        }

        public void TakeDamage(int amount, GameObject sender)
        {
            if (IsFriendly(sender)) return;
            if (isDead)
                return;
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            OnHit?.Invoke();
            if (currentHealth <= 0)
            {
                isDead = true;
                OnDeathEvent?.Invoke();
                OnDeathWithReference?.Invoke(sender);
            }
            if (amount > 0)
            {
                isFull = false;
            }
            SaveHP();
            OnHealthChange?.Invoke(currentHealth);
            
        }

        private bool IsFriendly(GameObject sender)
        {
            if (sender.layer == gameObject.layer)
            {
                return true;
            }
            return false;
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
                isFull= true;
            }
            SaveHP();
            OnHealthChange?.Invoke(currentHealth);
            
            
        }
        public void SaveHP()
        {
            PlayerPrefs.SetInt("currentHealth", currentHealth);
            PlayerPrefs.SetInt("maxHealth", maxHealth);
            PlayerPrefs.Save();
        }
        public void LoadHP()
        {
            PlayerPrefs.GetInt("currentHealth", currentHealth);
            PlayerPrefs.GetInt("maxHealth", maxHealth);
        }
        
    }
}