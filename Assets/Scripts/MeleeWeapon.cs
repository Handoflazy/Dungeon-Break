using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    private LayerMask layerMask;
    private SlashAnim slashAnim;
    private DamageSource damageSource;
    private void Start()
    {
        WeaponType = WeaponType.Melee;
        WeaponAnim = GetComponent<Animator>();
        weaponParent = transform.parent.GetComponent<WeaponParent>();
        slashAnim = transform.root.GetComponentInChildren<SlashAnim>();
        damageSource = GetComponent<DamageSource>();
        damageSource.OnHitEnemy += OnTriggerWeapon;
        
    }

    
    public  virtual void CompleteSwingEvent()
    {
        weaponParent.ResetIsAttacking();
        slashAnim.DeactivateEffect();

    }
    public  void ActivateSlashEffect()
    {
        slashAnim.ActivateEffect();
    }
    IEnumerator RevertColor(SpriteRenderer render)
    {
        yield return new WaitForSeconds(0.2f);
        render.color = Color.white;
    }

    public override void Attack()
    {
        WeaponAnim.SetTrigger("Attack");
    }
    protected virtual void OnCollide(Collider2D other)
    {
        SpriteRenderer Render = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Render.color = Color.red;
        StartCoroutine(RevertColor(Render));
    }

    private void SetDamageSource()
    {

    }
}
