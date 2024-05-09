using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Shooter;

public class AgentParent : PlayerSystem
{
    [SerializeField] protected BasicGun CurrentGun;
    [SerializeField] protected GunEquipmentSO GunData;

    public BoolEvent OnUsingWeapon;

    [SerializeField] protected WeaponRenderer weaponRenderer;

    [SerializeField] private GameObject dropWeaponPrefab;

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

    }
    private void OnDisable()
    {
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
        CurrentGun = GetComponentInChildren<BasicGun>();
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
    public void SetWeapon(GunEquipmentSO newGun, int bulletNumber)
    {
        if (CurrentGun)
        {
            
            dropWeaponPrefab.GetComponent<Shooter.DropWeapon>().Gun = GunData;
            dropWeaponPrefab.GetComponent<Shooter.DropWeapon>().BulletNumber = CurrentGun.Ammo;
            DropCurrentWeapon(dropWeaponPrefab);
            Destroy(CurrentGun.gameObject);
        }
        GunData = newGun;
        SpawnWeapon(newGun.WeaponPrefab);
        CurrentGun.Ammo = bulletNumber;
        player.ID.playerEvents.OnChangeGun(CurrentGun);

    }
    private void DropCurrentWeapon(GameObject GunToDrop)
    {
        Instantiate(GunToDrop, transform.position, Quaternion.identity);
    }

    private void SpawnWeapon(GameObject gunPrefab)
    {
        GameObject newWeapon = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        newWeapon.transform.SetParent(gameObject.transform, false);
        newWeapon.transform.localPosition = gunPrefab.transform.position;
        CurrentGun = newWeapon.GetComponent<BasicGun>();
        
    }

    public void Shoot()
    {
        if (CurrentGun)
            CurrentGun.TryShooting();

    }

    public void StopShoot()
    {
        if (CurrentGun)
            CurrentGun?.StopShoot();
    }
}

