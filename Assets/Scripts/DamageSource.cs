using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageSource : PlayerSystem
{
    public UnityEvent OnDeathEvent;
    [SerializeField] private LayerMask ignoreMask;
    private void OnEnable()
    {
        NguyenSingleton.Instance.ActiveInventory.OnWeaponChanged += OnChangeWeapon;
    }
    public Weapon weapon;

    private void Start()
    {
        weapon = GameObject.Find("Player").GetComponentInChildren<Weapon>();
    }
    void OnChangeWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((ignoreMask & (1 << other.gameObject.layer)) != 0) { return; }
        Damage dmg = new() { damageAmount = weapon.damagePoint, origin = transform.position, pushForce = weapon.pushForce };

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
