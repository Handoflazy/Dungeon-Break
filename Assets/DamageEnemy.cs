using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : PlayerSystem
{
    public UnityEvent OnDeathEvent;
    [SerializeField] private LayerMask ignoreMask;

    public int damage;
    public float pushForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((ignoreMask & (1 << other.gameObject.layer)) != 0) { return; }
        Damage dmg = new() { damageAmount = damage, origin = transform.position, pushForce = pushForce };

        if (other.gameObject.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(dmg, this.gameObject);
        }
        else
        {
            Debug.Log("That object cannot be damaged.");
        }

        OnDeathEvent?.Invoke();
        
    }
}
