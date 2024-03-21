using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Mover
{

    private SpriteRenderer spriteRenderer;
    public HeartBar heartBar;
    private bool isAlive;
    public Animator anim;
    // Update is called once per frame
    private void Awake()
    {
        isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        heartBar.SetMaxHearth(maxHitPoint);
        heartBar.SetHealth(hitPoint);

   
    }
    protected override void ReceivedDamage(Damage dmg)
    {
        if(!isAlive) { return; }
        base.ReceivedDamage(dmg);
    }
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public void SetRender(int id)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[id];
    }
    public void Respawn()
    {
        hitPoint = maxHitPoint;
        isAlive=true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
    void Update()
    {
        heartBar.SetHealth(hitPoint);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 input = new(horizontalInput, verticalInput, 0);
        if (isAlive)
        {
            UpdateMotor(input.normalized);
            print(input.magnitude);
            anim.SetFloat("speed", input.magnitude);
            
        }
    }
    public void OnLevelUp(){
        maxHitPoint++;
        hitPoint = maxHitPoint;
        GameManager.instance.ShowText("Level Up!", 30, Color.green, transform.position, Vector3.up, 2.0f);
        heartBar.SetMaxHearth(maxHitPoint);
   }
   
    public void Healing(int healingAmount)
    {
        if (hitPoint == maxHitPoint)
        {
            return;
        }
        hitPoint += healingAmount;
        if(hitPoint> maxHitPoint)
        {
            hitPoint = maxHitPoint;
        }
        else
        {
            GameManager.instance.ShowText("+" + healingAmount.ToString()+ "HP",30, Color.green, transform.position, Vector3.up*30, 1.0f);
        }
    }
    protected override void Death()
    {
        isAlive = false;
        base.Death();
        GameManager.instance.deathAim.SetBool("isDeath", true);
    }

}
