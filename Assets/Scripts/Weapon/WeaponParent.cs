using Inventory.Model;
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

    
    [SerializeField] private AudioClip swingSound;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip fireSound;

    [SerializeField]
    private EquippabeItemSO weapon;
    [SerializeField]
    private InventorySO inventoryData;
    private List<ItemParameter> parametersToModify;
    [field: SerializeField]
    public List<ItemParameter> itemCurrentState;

    public Vector2 Pointerposition { get; set; }
    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private bool attackBlocked;
    [SerializeField]
    private float attackDelayTime;
    public bool IsAttacking { get; set; }

    private void OnEnable()
    {
        player.ID.playerEvents.OnAttack += Attack;

    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnAttack -= Attack;
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
        PlayWeaponSound();
        OnUsingWeapon?.Invoke(true);
        player.ID.playerEvents.OnUsingWeapon?.Invoke(true);
        IsAttacking = true;
        AttackCooldown();
        (currentActiveWeapon as IWeapon).Attack();
    }
    private void PlayWeaponSound()
    {
        AudioClip clip;
        switch (currentActiveWeapon.WeaponType)
        {
            case WeaponType.Melee:
                clip = swingSound;
                break;
            case WeaponType.Staff:
                clip = fireSound;
                break;
            case WeaponType.Range:
                clip = shotSound;
                break;
            default:
                clip = null;
                break;
        }
        NguyenSingleton.Instance.AudioManager.PlaySFX(clip);
    }
    public void SetWeapon(EquippabeItemSO weaponItemS0, List<ItemParameter> itemState)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1, itemCurrentState);
            Destroy(currentActiveWeapon.gameObject);
        }
        this.weapon = weaponItemS0;
        itemCurrentState = new List<ItemParameter>(itemState);
        SpawnWeapon();
    }

    private void ModifyParameters()
    {
        foreach (var parameter in parametersToModify)
        {
            if (itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }
    private void SpawnWeapon()
    {
        transform.right = Vector3.zero;
        GameObject WeaponToSpawn = weapon.WeaponPrefap;
        GameObject newWeapon = Instantiate(WeaponToSpawn, transform.position, Quaternion.identity);
        newWeapon.transform.SetParent(gameObject.transform, false);
        currentActiveWeapon = newWeapon.GetComponent<Weapon>();
        player.ID.playerEvents.OnChangeWeapon?.Invoke(currentActiveWeapon);
    }
}

