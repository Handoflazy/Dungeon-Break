using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed;

    //[SerializeField] Rigidbody2D rb;
    //Push
    protected Vector3 pushDirection;

    // immune system
    protected float immunetime = 1.0f;
    protected float lastImmune;
    void Start()
    {
       
        hitPoint = maxHitPoint;
    }

    //All fighter can ReceiveDame / Die
    protected virtual void ReceivedDamage(Damage dmg)
    {
        if (Time.time -lastImmune > immunetime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
           
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.zero, 0.5f);
           
            if(hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

   protected virtual void Death()
    {
        print(gameObject.name + "is Death");
    }
}
