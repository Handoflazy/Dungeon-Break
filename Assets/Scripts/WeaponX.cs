using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //Damage struct
    public int[] damagePoint = { 1, 2, 4, 6, 9 };
    public float[] pushForce = { 1f, 2f, 2.7f, 3.5f, 5f, 7f };
    
    //Swing
    private Animator anim;
    public float cooldown = 0.5f;
    public float lastWing;
    //Upgrade
    public int weaponLevel = 0;
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
                Damage dmg = new() { damageAmount = damagePoint[weaponLevel], origin = transform.position, pushForce = pushForce[weaponLevel] };
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
        anim.SetTrigger("Swing");
    }
    public void UpgradeWeapon()
    {
        weaponLevel++;
        SpriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        //change stat

    }
    public void SetLevelWeapon(int level)
    {
        
        weaponLevel = level;
        SpriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
