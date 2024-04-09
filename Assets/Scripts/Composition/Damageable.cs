using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;


[RequireComponent(typeof(Health))]
public class Damageable : PlayerSystem
{
    Vector2 pushDirection;
    protected override void Awake()
    {
        base.Awake();
    }
    public void DealDamage(Damage dmg)
    {
        
        player.ID.playerEvents.onTakeDamage?.Invoke(dmg.damageAmount);
        NguyenSingleton.Instance.floatingTextManager.Show(dmg.damageAmount.ToString(), 10, Color.red, transform.position, Vector3.zero, 0.5f);
        if (dmg.pushForce > 0)
        {
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            player.ID.playerEvents.OnBeginPush?.Invoke(pushDirection);
        }
    }
}
