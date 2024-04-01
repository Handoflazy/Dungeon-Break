using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponX : Collidable
{
    //Damage struct
    public int damagePoint = 5;
    public float pushForce = 2;
    
    //Swing
    private Animator anim;
    //Upgrade
    private SpriteRenderer SpriteRenderer;
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
        
        anim = GetComponent<Animator>();
       
    }
    protected override void OnCollide(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fighter"))
        {
            if(other.name!="Player")
            {
                Damage dmg = new() { damageAmount = damagePoint, origin = transform.position, pushForce = pushForce };
                other.SendMessage("ReceivedDamage", dmg);
            }
        }
    }
}
