using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Shooter;

public class WeaponParent : PlayerSystem
{
    [SerializeField] protected BasicGun CurrentGun;


    [SerializeField] protected WeaponRenderer weaponRenderer;

    [SerializeField] private GameObject dropWeaponPrefab;
    [SerializeField]
    private GameObject currentItemPrefab;

    public List<ItemParameter> itemCurrentState;
    public List<GameObject> weapons;

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

    protected override void Awake()
    {
        base.Awake();
        if (PlayerPrefs.HasKey(PrefConsts.CURRENT_GUN_KEY))
        {
            int indexCurrenGun = PlayerPrefs.GetInt(PrefConsts.CURRENT_GUN_KEY);
            int bullet = 0;

            if (PlayerPrefs.HasKey(PrefConsts.CURRENT_BULLET_COUNT_KEY))
            {
                bullet = PlayerPrefs.GetInt(PrefConsts.CURRENT_BULLET_COUNT_KEY);
            }
            SetWeapon(weapons[indexCurrenGun], bullet);
        }
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

        if (!CurrentGun) return;
        PlayerPrefs.SetInt(PrefConsts.CURRENT_BULLET_COUNT_KEY, CurrentGun.Ammo);
    }

    private void AdjustWeaponRederrer()
    {
        if (weaponRenderer)
            weaponRenderer.RenderBehindHead(direction.x > 0);
    }



    public void SetWeapon(GameObject newGun, int bulletNumber)
    {
        if (CurrentGun)
        {      
            DropCurrentWeapon();
        }
        SpawnWeapon(newGun);
        currentItemPrefab = newGun;
        CurrentGun.Ammo = bulletNumber;
        player.ID.playerEvents.OnChangeGun?.Invoke(CurrentGun);
      

    }
    private void DropCurrentWeapon()
    {
        GameObject GunToDrop = dropWeaponPrefab;
        GunToDrop.GetComponent<DropWeapon>().GunPrefab = currentItemPrefab;
        GunToDrop.GetComponent<DropWeapon>().BulletNumber = CurrentGun.Ammo;
        Instantiate(GunToDrop, transform.position, Quaternion.identity);
        CurrentGun.gameObject.transform.parent = null;
        Destroy(CurrentGun.gameObject);
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

