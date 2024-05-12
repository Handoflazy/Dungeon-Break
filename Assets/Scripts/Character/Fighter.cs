using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fighter : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    public float pushRecoverySpeed;
    protected Vector3 pushDirection;

    // immune system
    protected float immunetime = 1.0f;
    protected float lastImmune;

    protected virtual void Start()
    {

       
    }

    //All fighter can ReceiveDame / Die
    protected virtual void ReceivedDamage(Damage dmg)
    {
       
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
        DGSingleton.Instance.FloatingTextManager.Show(dmg.damageAmount.ToString(), 30, UnityEngine.Color.red, transform.position, Vector3.zero, 0.5f);
    }

    public virtual void Death()
    {
        print(gameObject.name + "is Death");
    }
}
