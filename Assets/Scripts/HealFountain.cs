using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFountain : Collectable
{
    [SerializeField] int healingAmount = 1;
    public float regespd = 1.0f;
    private bool isInside;
    private float lastTime;

    // Start is called before the first frame update
    protected override void OnCollide(Collider2D other)
    {
        if (other.name != "Player")
        {
            return;
        }
        if (Time.time - lastTime > regespd)
        {
            lastTime = Time.time;
            GameManager.instance.player.Healing(healingAmount);
        }
    }

    
   


}
