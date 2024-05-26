using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    public static ObjectPoolEnemy SharedInstance;
    public List<GameObject> pooledBulletBoss;
    public List<GameObject> pooledBulletEnemy;
    public GameObject bulletBossToPool;
    public GameObject bulletEnemyToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledBulletBoss = new List<GameObject>();
        GameObject bulletBoss;
        for (int i = 0; i < amountToPool; i++)
        {
            bulletBoss = Instantiate(bulletBossToPool);
            bulletBoss.SetActive(false);
            pooledBulletBoss.Add(bulletBoss);
        }

        pooledBulletEnemy = new List<GameObject>();
        GameObject bulletEnemy;
        for (int i = 0; i < amountToPool; i++)
        {
            bulletEnemy = Instantiate(bulletEnemyToPool);
            bulletEnemy.SetActive(false);
            pooledBulletEnemy.Add(bulletEnemy);
        }
    }

    public GameObject GetPooledBulletBoss()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBulletBoss[i].activeInHierarchy)
            {
                return pooledBulletBoss[i];
            }
        }
        return null;
    }

    public GameObject GetPooledBulletEnemy()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBulletEnemy[i].activeInHierarchy)
            {
                return pooledBulletEnemy[i];
            }
        }
        return null;
    }
}
