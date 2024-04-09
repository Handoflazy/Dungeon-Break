using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public MeleeWeapon weapon;
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.gameObject.CompareTag("Fighter")&&other.gameObject.name!="Player"){
            Damage dmg = new() { damageAmount = weapon.damagePoint, origin = transform.position, pushForce = weapon.pushForce };
        
            if (other.gameObject.TryGetComponent(out Damageable damageableObject))
            {
                damageableObject.DealDamage(dmg);
                Flash flashit = other.GetComponentInChildren<Flash>();
                if (flashit)
                {
                    StartCoroutine(flashit.FlashRoutine());
                }
            }
            else
            {
                Debug.Log("That object cannot be damaged.");
            }
          
            
        }

    }
}
