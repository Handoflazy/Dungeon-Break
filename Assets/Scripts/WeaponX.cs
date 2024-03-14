using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    [SerializeField] int damagePoint = 1;
    [SerializeField] float pushForce = 3.0f;
    public int weaponLevel = 0;
    private SpriteRenderer SpriteRenderer;
    public float cooldown = 0.5f;
    public float lastWing;
    protected override void Start()
    {
        base.Start();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void OnCollide(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fighter"))
        {
            if(other.name!="Player")
            {
                Damage dmg = new Damage { damageAmount = damagePoint, origin = transform.position, pushForce = pushForce };
                other.SendMessage("ReceivedDamage", dmg);
            }
        }
    }
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(Time.time - lastWing>cooldown) {
                lastWing = Time.time;
                Swing();
            }
        }
        
    }
    private void Swing()
    {
        print("Swing");
    }
}
