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
        public UnityEvent<int> OnHealthChange,SetMaxHealthBar;
        public UnityEvent OnHit;


        public bool isFull { get; set; }


        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

        private void Start()
        {
            SetMaxHealth();
            OnHealthChange?.Invoke(currentHealth);
        }
        public virtual void SetMaxHealth()
        {
            SetMaxHealthBar?.Invoke(maxHealth);
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

            currentHealth = PlayerPrefs.GetInt("currentHealth");
            if(currentHealth >= maxHealth) isFull = true;
            if(currentHealth > 0) isDead = false;
        }
        
    }
}