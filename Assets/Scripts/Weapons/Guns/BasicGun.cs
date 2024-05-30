using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;
using Random = UnityEngine.Random;

public class BasicGun : PlayerSystem
{
    [SerializeField]
    protected GameObject muzzle;
    [SerializeField]
    private int ammo = 10;
    [SerializeField]
    protected GunWeaponDataSO weaponData;
    [SerializeField]
    public int speedFactor = 1;  //Tốc độ bắn

    [SerializeField]
    protected BulletGenerator bulletPool;
    public int Ammo
    {
        get => ammo; set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
            
        }
        
    }

    public bool AmmoFull { get =>Ammo>=weaponData.AmmoCapacity; }

    protected bool isShooting = false;

    [SerializeField]
    protected bool reloadCoroutine = false;
    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }

    public bool IsReloading { get; set; } = false;

    [field:SerializeField]

    public UnityEvent OnShootNoAmmo { get; set; }

    [field: SerializeField]
    public UnityEvent OnLoadAmmo {  get; set; }

    private void Start()
    {
        bulletPool = GetComponentInChildren<BulletGenerator>();
        if (!player)
        {
            player = transform.root.GetComponent<Player>();
        }
        player.ID.playerEvents.OnUpdateAmmo?.Invoke(Ammo);
    }

    public void TryShooting()
    {
        isShooting = true;

    }

    public void StopShoot()
    {
        isShooting = false;
    }

    public void Reload(int ammo)
    {
        Ammo += ammo;
        player.ID.playerEvents.OnUpdateAmmo?.Invoke(Ammo);
    }
    public void FullReload()
    {
        StartCoroutine(StartReload(weaponData.AmmoCapacity-Ammo));
    }
    public IEnumerator StartReload(int ammo)    
    {
        IsReloading = true;
        while (ammo>0&&!AmmoFull)
        {
            yield return new WaitForSeconds(0.5f);
            int ammoToload = Mathf.Clamp(ammo, 0, 10);
            ammo -= ammoToload;
            Reload(Mathf.Clamp(ammoToload, 0, 10));
            OnLoadAmmo?.Invoke();
            player.ID.playerEvents.OnUpdateAmmo?.Invoke(Ammo);
        }
        IsReloading = false;
    }
    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if(isShooting&&reloadCoroutine == false&&!IsReloading)
        {
            if (Ammo > 0)
            {
                Ammo--;
                if (OnShoot!=null)
                {
                    OnShoot.Invoke();
                }
                for (int i = 0; i < weaponData.GetButtetCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting=false;
                OnShootNoAmmo?.Invoke();
                NguyenSingleton.Instance.FloatingTextManager.Show("Out of Ammor", 20, Color.red, transform.position, Vector3.up, weaponData.WeaponDelay);
                return;
            }
            FinishShoot();
        }
    }

    private void FinishShoot()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if(weaponData.AutomaticFire == false)
        {
            isShooting = false;
        }
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay / speedFactor); //Tốc độ bắn
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnButllet(muzzle.transform.position, CalculateAngle(muzzle));
        player.ID.playerEvents.OnUpdateAmmo?.Invoke(Ammo);

    }

    private void SpawnButllet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = bulletPool.GetBullet();
        bulletPrefab.transform.position = muzzle.transform.position;
        bulletPrefab.transform.rotation = rotation;
        bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotaion = Quaternion.Euler(new Vector3(0,0,spread));
        return muzzle.transform.rotation * bulletSpreadRotaion;
    }

    internal BulletDataSO GetBulletData()
    {
        return weaponData.BulletData;
    }
}
