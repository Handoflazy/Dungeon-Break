using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaponParent : PlayerSystem
{
    [SerializeField] private Weapon currentActiveWeapon;
    public BoolEvent OnUsingWeapon;

    public Vector2 Pointerposition { get; set; }
    [SerializeField]
    private SpriteRenderer playerRenderer;
    //[SerializeField]
   // private SpriteRenderer weaponRenderer;
    [SerializeField]
    private bool attackBlocked;
    [SerializeField]
    private float attackDelayTime;
    public bool IsAttacking { get; set; }
    [SerializeField]
    public Transform MeleeWeaponCollider; 

    private void OnEnable()
    {
        player.ID.playerEvents.OnAttack += Attack;
        player.ID.playerEvents.OnChangeWeapon += ChangeWeapon;
    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnAttack -= Attack;
        player.ID.playerEvents.OnChangeWeapon -= ChangeWeapon;

    }
    private Vector2 GetPointerPos()
    {
        Vector3 mousePos;
        mousePos.x = Mouse.current.position.x.ReadValue();
        mousePos.y = Mouse.current.position.y.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void Start()
    {
        AttackCooldown();
    }

    Vector2 direction;
    private void Update()
    {
        if (IsAttacking)
            return;
        direction = (GetPointerPos() - (Vector2)transform.position).normalized;

        Vector2 scale = transform.localScale;
        scale.x = 1;
        if (direction.x < 0)
        {
                scale.y = -1;
        }
        else if (direction.x > 0) scale.y = 1;
        //if (currentActiveWeapon.WeaponType == WeaponType.Melee)
        //{
        //    scale.y = 1;
        //    return;
        //}
        if (direction.y > -0.9)
        {
           transform.right = direction;
           transform.localScale = scale;
        }

    }

    public void ResetIsAttacking()
    {
        OnUsingWeapon?.Invoke(false);
        IsAttacking = false;
        player.ID.playerEvents.OnUsingWeapon?.Invoke(false);
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelayTime);
        attackBlocked = false;
        ResetIsAttacking();
    }
    
    public void ChangeWeapon(Weapon newWeapon)
    {
        
        transform.right = Vector3.zero;
        if (currentActiveWeapon != null)
        {
            Destroy(currentActiveWeapon.gameObject);
        }
        
        currentActiveWeapon = newWeapon;
        if (!newWeapon)       
            return;
       
        attackDelayTime = currentActiveWeapon.GetWeaponInfo().weaponCoolDown;
        AttackCooldown();
       

    }
    private void AttackCooldown()
    {
        attackBlocked = true;
        StopAllCoroutines();
        StartCoroutine(AttackDelay());
    }
    public void Attack()
    {
        if (attackBlocked || !currentActiveWeapon)
            return;
        OnUsingWeapon?.Invoke(true);
        player.ID.playerEvents.OnUsingWeapon?.Invoke(true);
        IsAttacking = true;
        AttackCooldown();
        (currentActiveWeapon as IWeapon).Attack();
    }

}

