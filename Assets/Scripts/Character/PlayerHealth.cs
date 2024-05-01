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
        private void Awake()
        {
            player = GetComponent<Player>();
            MaxHealth = player.playerStats.hp;
        }

    }
}