using FirstVersion;
using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DamageSource : PlayerSystem
{
    public UnityEvent OnDeathEvent;
    [SerializeField] private LayerMask targetMask, ignoreMask;
    public event Action<GameObject> OnHitEnemy;
    

    private void OnTriggerEnter2D(Collider2D other)
    {


        if ((ignoreMask & (1 << other.gameObject.layer)) != 0)
        {
            return;

        }
        if ((targetMask & (1 << other.gameObject.layer)) != 0)
        {
            OnHitEnemy?.Invoke(other.gameObject);
           
        }
        OnDeathEvent?.Invoke();

    }
}
