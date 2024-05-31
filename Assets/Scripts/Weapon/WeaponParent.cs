using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Shooter;
using Unity.VisualScripting;
using Inventory.UI;

public class WeaponParent : PlayerSystem
{
    [field: SerializeField] public BasicGun CurrentGun { get; set; }
    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField] protected WeaponRenderer weaponRenderer;

    [SerializeField]
    private EquipableItemSO WeaponSO;

    public List<ItemParameter> itemCurrentState;

    public List<EquipableItemSO> weapons;

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
        player.ID.playerEvents.OnReloadBullet += QuickReloadBullet;

    }
    

    private void QuickReloadBullet()
    {
        if (inventoryData&& CurrentGun)
        {
            if (CurrentGun.AmmoFull)
            {
                NguyenSingleton.Instance.FloatingTextManager.Show("Full Ammo", 40, Color.white, transform.position, Vector3.up, 0.3f);
                return;
            }
            int bulletIndex = inventoryData.SearchItemIndex(WeaponSO.BulletItemSO);
            if (bulletIndex != -1)
            {
                InventoryItem inventoryItem = inventoryData.GetItemAt(bulletIndex);
                if (inventoryItem.IsEmpty) return;
                IItemAction itemAction = inventoryItem.item as IItemAction;
                if (itemAction != null)
                {
                    if(itemAction.PerformAction(gameObject, inventoryItem.itemState))
                        inventoryData.RemoveItem(bulletIndex, 1);

                }
            }
            else
            {
                NguyenSingleton.Instance.FloatingTextManager.Show("No suitable Ammo in inventory", 40, Color.red, transform.position, Vector3.up, 0.3f);
            }
        }
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnPressed -= Shoot;
        player.ID.playerEvents.OnRelease -= StopShoot;
        player.ID.playerEvents.OnReloadBullet -= QuickReloadBullet;
        if (WeaponSO == null) return;
        if (WeaponSO.name == "Assaut Riffle Item")
        {
            PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 0);
        }
        else if (WeaponSO.name == "ShotGunItemData")
        {
            PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 1);
        }
        else if (WeaponSO.name == "PistolGun")
        {
            PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 2);
        }
        else if (WeaponSO.name == "MP5")
        {
            PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 3);
        }
        else if (WeaponSO.name == "ThomsonItemData")
        {
            PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 4);
        }
        PlayerPrefs.SetInt(PrefConsts.CURRENT_BULLET_COUNT_KEY, CurrentGun.Ammo);
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

    private void Start()
    {
        player.ID.playerEvents.OnChangeGun?.Invoke(CurrentGun);
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



    public void SetWeapon(EquipableItemSO weaponItemS0, int bulletNumber)
    {
        if (weaponItemS0 == null)
            return;
        if (CurrentGun)
        {
            if (inventoryData.AddItem(WeaponSO, 1)==1)
            {
                player.ID.playerEvents.OnDropItem(WeaponSO, 1);
            }
            Destroy(CurrentGun.gameObject);
        }
        SpawnWeapon(weaponItemS0.WeaponPrefap);
        this.WeaponSO = weaponItemS0;
        CurrentGun.Ammo = bulletNumber;
        player.ID.playerEvents.OnChangeGun?.Invoke(CurrentGun);


    }




    //private void DropCurrentWeapon()
    //{
    //    GameObject GunToDrop = dropWeaponPrefab;
    //    GunToDrop.GetComponent<DropWeapon>().GunPrefab = currentItemPrefab;
    //    GunToDrop.GetComponent<DropWeapon>().BulletNumber = CurrentGun.Ammo;
    //    Instantiate(GunToDrop, transform.position, Quaternion.identity);
    //    CurrentGun.gameObject.transform.parent = null;
    //    Destroy(CurrentGun.gameObject);
    //}

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
            CurrentGun?.TryShooting();

    }

    public void StopShoot()
    {
        if (CurrentGun)
            CurrentGun?.StopShoot();
        
    }
    public BulletDataSO GetCurrentUsingBullet()
    {
        if (CurrentGun)
        {
            return CurrentGun.GetBulletData();
            
        }
        return null;
    }
}

