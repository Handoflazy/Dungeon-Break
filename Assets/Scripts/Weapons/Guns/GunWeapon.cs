using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GunWeapon : PlayerSystem
{
    [SerializeField]
    protected GameObject muzzle;
    [SerializeField]
    private int ammo = 10;
    [SerializeField]
    protected GunWeaponDataSO weaponData;
    [SerializeField]
    public int speedFactor = 1;  //Tốc độ bắn

    protected int Ammo
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

    [field:SerializeField]

    public UnityEvent OnShootNoAmmo { get; set; }

    private void Start()
    {
        Ammo = weaponData.AmmoCapacity;
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
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if(isShooting&&reloadCoroutine == false)
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
    }

    private void SpawnButllet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, rotation);
        bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotaion = Quaternion.Euler(new Vector3(0,0,spread));
        return muzzle.transform.rotation * bulletSpreadRotaion;
    }
}
