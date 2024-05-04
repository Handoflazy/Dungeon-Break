using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentParent : PlayerSystem
{
    [SerializeField] private Weapon currentActiveWeapon;
    [SerializeField] protected GunWeapon gunWeapon;


    public BoolEvent OnUsingWeapon;

    [SerializeField] protected WeaponRenderer weaponRenderer;

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


    protected float desireAngle;
    public Vector2 Pointerposition { get; set; }
    [SerializeField]
    private bool attackBlocked;
    [SerializeField]
    private float attackDelayTime;
    public bool IsAttacking { get; set; }

    private void OnEnable()
    {
        player.ID.playerEvents.OnPressed += Shoot;
        player.ID.playerEvents.OnRelease += StopShoot;
        player.ID.playerEvents.OnAttack += Attack;

    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnAttack -= Attack;
        player.ID.playerEvents.OnPressed -= Shoot;
        player.ID.playerEvents.OnRelease -= StopShoot;
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
        gunWeapon = GetComponentInChildren<GunWeapon>();
        AttackCooldown();
    }

    Vector2 direction;
    private void Update()
    {
        if (IsAttacking)
            return;
        direction = (GetPointerPos() - (Vector2)transform.position).normalized;
        desireAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector2 scale = transform.localScale;

        scale.x = 1;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0) scale.y = 1;

        AdjustWeaponRederrer();
        transform.rotation = Quaternion.AngleAxis(desireAngle, Vector3.forward);
        transform.localScale = scale;


    }

    private void AdjustWeaponRederrer()
    {
        if (weaponRenderer)
            weaponRenderer.RenderBehindHead(direction.x > 0);
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
        currentActiveWeapon.Attack();
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

    public void Shoot()
    {
        if (gunWeapon)
            gunWeapon.TryShooting();

    }

    public void StopShoot()
    {
        if (gunWeapon)
            gunWeapon?.StopShoot();
    }
}

