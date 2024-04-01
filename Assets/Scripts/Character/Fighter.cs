using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected Health health;
    [SerializeField]
    protected int maxHealth;
    public float pushRecoverySpeed;
    protected Vector3 pushDirection;

    // immune system
    protected float immunetime = 1.0f;
    protected float lastImmune;
    void Start()
    {

        health.InitialHealth(maxHealth);
    }

    //All fighter can ReceiveDame / Die
    protected virtual void ReceivedDamage(Damage dmg)
    {
        health.TakeDame(dmg.damageAmount);
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        // GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.zero, 0.5f);

       if(health.CurrentHealth <= 0)
        {
            Death();
        }
    }

   protected virtual void Death()
    {
        print(gameObject.name + "is Death");
    }
}
