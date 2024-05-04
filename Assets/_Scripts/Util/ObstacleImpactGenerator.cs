using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleImpactGenerator : ObjectPool
{
    public GameObject GetBullet()
    {
        GameObject Bullet = SpawnObject();
        if (Bullet.activeSelf == false)
        {
            Bullet.SetActive(true);
        }
        return Bullet;
    }
}
