using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using PlayerController;
using SunnyValleyVersion;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Vector2 pushDirection;
    Health health;
    public Vector2DEvent OnPushForce;
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void DealDamage(Damage dmg, GameObject sender)
    {
         
        NguyenSingleton.Instance.FloatingTextManager.Show(dmg.damageAmount.ToString(), 10, Color.red, transform.position, Vector3.zero, 0.5f);
        health.TakeDamage(dmg.damageAmount, sender);
        if (dmg.pushForce > 0)
        {
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            OnPushForce?.Invoke(pushDirection);
        }
    }
}
