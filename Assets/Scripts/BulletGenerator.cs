using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : ObjectPool
{
    GameObject bulletToSpawn;
    private void Start()
    {
       bulletToSpawn = transform.parent.GetComponent<BasicGun>().GetBulletData().BulletPrefab;
    }
    public GameObject GetBullet()
    {
        GameObject Bullet = SpawnObject(bulletToSpawn);
        if(Bullet.activeSelf == false)
        {
            Bullet.SetActive(true);
        }
        return Bullet;
    }
}
