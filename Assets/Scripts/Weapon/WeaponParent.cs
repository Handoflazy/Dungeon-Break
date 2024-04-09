using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WeaponParent : PlayerSystem
{
    
    public UnityEvent onUseWeapon;
    public Weapon equipmentWeapon;
    public Vector2 Pointerposition { get; set; }
    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private SpriteRenderer weaponRenderer;
    [SerializeField]
    private bool attackBlocked;
    [SerializeField]
    private float attackDelayTime;
    public bool IsAttacking { get; set; }

   
    private void OnEnable()
    {
        player.ID.playerEvents.OnAttack += Attack;
        player.ID.playerEvents.OnMousePointer += GetPointerPos;

       
    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnAttack -= Attack;
        player.ID.playerEvents.OnMousePointer -= GetPointerPos;
       
    }
    private void Start()
    {
        equipmentWeapon = transform.GetComponentInChildren<Weapon>();
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void GetPointerPos(Vector2 pointerPos)
    {
        Pointerposition = pointerPos;
    }

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (Pointerposition - (Vector2)transform.position).normalized;
        if (direction.y < 0.64 && direction.y > -0.9)
        {
            if (direction.x < 0)
                transform.rotation = Quaternion.Euler(0, -180, 0);
            else if (direction.x > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
            if (equipmentWeapon._weaponType != WeaponType.Melee)
            {
                transform.right = direction;        
            }
        }

    }

    public void ResetIsAttacking()
    {
        player.ID.playerEvents.OnUsingWeapon?.Invoke(false);
        IsAttacking = false;
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelayTime);
        attackBlocked = false;
    }

    public void Attack()
    {
        if (attackBlocked)
            return;

        player.ID.playerEvents.OnUsingWeapon?.Invoke(true);
        IsAttacking = true;
        attackBlocked = true;
        anim.SetTrigger("Attack");
        StartCoroutine(AttackDelay());
    }

}

