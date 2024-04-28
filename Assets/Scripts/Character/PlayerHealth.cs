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
        protected PlayerReform player;
        private void Awake()
        {
            player = GetComponent<PlayerReform>();
            MaxHealth = player.playerStats.hp;
        }

    }
}