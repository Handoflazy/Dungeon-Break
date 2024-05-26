using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FirstVersion;

public class EnemyBullet : MonoBehaviour
{
    //public UnityEvent OnDeathEvent;
    [SerializeField] private LayerMask ignoreMask;
    [SerializeField]
    private int damage;

    public int Damage { get => damage; set => damage = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((ignoreMask & (1 << other.gameObject.layer)) != 0) { return; }
        Damage dmg = new() { damageAmount = Damage, origin = transform.position};

        if (other.gameObject.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(Damage,this.gameObject);
        }
        else
        {
            Debug.Log("That object cannot be damaged.");
        }

        //OnDeathEvent?.Invoke();
        
    }
}
