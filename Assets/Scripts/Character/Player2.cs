using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player2 : Mover
{
    [Header("Reference")]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
   
    private bool isAlive;
    public Animator anim;
    // Update is called once per frame
    private void Awake()
    {
        isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
       

   
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
    Vector2 input;
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        input = new(horizontalInput, verticalInput);
        if (input.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (input.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        anim.SetBool("isWalking", input.magnitude > 0);

        

    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            UpdateMotor(input.normalized);

         


        }
    }
    protected override void UpdateMotor(Vector2 Input)
    {
        moveDelta = Input;
      
        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, moveDelta, Mathf.Abs(moveDelta.magnitude * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));

        if (hit.collider == null)
        {
           rb.AddForce(input*speed*Time.deltaTime,ForceMode2D.Impulse);
        }
    }
    public void OnLevelUp(){
        maxHitPoint++;
        hitPoint = maxHitPoint;
        GameManager.instance.ShowText("Level Up!", 30, Color.green, transform.position, Vector3.up, 2.0f);
     
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
        //GameManager.instance.deathAim.SetBool("isDeath", true);
    }

}
