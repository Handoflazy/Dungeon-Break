using FirstVersion;
using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageSource : PlayerSystem
{
    public UnityEvent OnDeathEvent;
    [SerializeField] private LayerMask targetMask;
    public event Action<GameObject> OnHitEnemy;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((targetMask & (1 << other.gameObject.layer)) != 0)
        {
            OnHitEnemy?.Invoke(other.gameObject);
           
        }
        OnDeathEvent?.Invoke();

    }
}
