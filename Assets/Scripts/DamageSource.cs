using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageSource : PlayerSystem
{
    public UnityEvent OnDeathEvent;
    [SerializeField] LayerMask ignoreLayer;
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
        if ((ignoreLayer & (1 << other.gameObject.layer)) != 1) {
            return;
        }
        if (other.gameObject.CompareTag("Fighter")&&other.gameObject.name!="Player"){
            Damage dmg = new() { damageAmount = weapon.damagePoint, origin = transform.position, pushForce = weapon.pushForce };
        
            if (other.gameObject.TryGetComponent(out Damageable damageableObject))
            {
                damageableObject.DealDamage(dmg,this.gameObject);
                if (other.gameObject.TryGetComponent(out Flash flashit))
                {
                    StartCoroutine(flashit.FlashRoutine());
                }
            }
            else
            {
                Debug.Log("That object cannot be damaged.");
            }

            OnDeathEvent?.Invoke();
        }
        OnDeathEvent?.Invoke();

    }
}
