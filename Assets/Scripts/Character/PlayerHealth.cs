using FirstVersion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerController
{

    public class PlayerHealth : Health
    {
        protected Player player;

        private void OnEnable()
        {
            player.ID.playerEvents.OnLevelUp += SetMaxHealth;
        }
        private void OnDisable()
        {
            player.ID.playerEvents.OnLevelUp -= SetMaxHealth;
        }
        private void Awake()
        {
            player = GetComponent<Player>();
            MaxHealth = player.playerStats.hp;
            LoadHP();
            if (!PlayerPrefs.HasKey(PrefConsts.CURRENT_HEALTH_KEY))
            {
                CurrentHealth = MaxHealth;
                SaveHP();
                print(CurrentHealth);
            }
            else 
            { 
                CurrentHealth = PlayerPrefs.GetInt(PrefConsts.CURRENT_HEALTH_KEY);
            }
            
        }

        public override void SetMaxHealth()
        {
            int temp = player.playerStats.hp - MaxHealth;

            MaxHealth = player.playerStats.hp;
            AddHealth(temp);

            SetMaxHealthBar?.Invoke(MaxHealth);
            SaveHP();
        }
        public void LateUpdate()
        {
            SaveHP();
        }

    }
}