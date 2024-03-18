using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{

    public int damage;
    public float pushForce;


    protected override void OnCollide(Collider2D other)
    {
        if (other.CompareTag("Fighter") && other.name == "Player")
        {
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            other.SendMessage("ReceivedDamage", dmg);
        }
    }
}
