using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDameEnemy : Fighter
{
    public int damage = 1;
    public float push = 3f;
    protected override void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage dmg = new() { damageAmount = damage , origin = transform.position, pushForce = push };
            collision.SendMessage("ReceivedDamage", dmg);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Blocking"))
        {
            gameObject.SetActive(false) ;
            //Destroy(gameObject);
        }
    }
}
