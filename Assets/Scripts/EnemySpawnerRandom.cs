using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerRandom : ObjectPool
{

    [SerializeField]
    private List<GameObject> spawnPoints;
    [SerializeField]
    private int count = 20;
    [SerializeField]
    private int saveCount;
    public List<GameObject> listEnemyPrefab;
    public List <GameObject> listEnemySpawned;
    [SerializeField]
    private float minDelay = .8f, maxDelay = 1.5f;
    private int indexRandomEnemy;
    public GameObject fenceToFalse;
    public int numberEnemyDie;
    private void OnEnable()
    {
        count = saveCount;
        if (spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint.transform.position);
            }
        }
        StartCoroutine(SpawnCoroutine());
        
    }

    private void OnDisable()
    {
        listEnemySpawned.Clear();
    }
    IEnumerator SpawnCoroutine()
    {
        while (count > 0)
        {
            count--;
            var randomIndex = Random.Range(0, spawnPoints.Count - 1);
            var randomOffset = Random.insideUnitCircle * 0.16f;
            

            var spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;
            SpawnEnemy(spawnPoint);
            var randomTimeDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomTimeDelay);
        }
    }

    private void SpawnEnemy(Vector3 spawnPoint)
    {
        //Instantiate(enemyPrefab,spawnPoint,Quaternion.identity);
        GetEnemy(spawnPoint);
    }

    private void GetEnemy(Vector3 spawnPoint)
    {
        indexRandomEnemy = Random.Range(0, listEnemyPrefab.Count - 1);
        GameObject newEnemy = SpawnObject(listEnemyPrefab[indexRandomEnemy]);
        newEnemy.SetActive(true);
        newEnemy.transform.position = spawnPoint;
        newEnemy.transform.rotation = listEnemyPrefab[indexRandomEnemy].transform.rotation;
        newEnemy.GetComponent<CapsuleCollider2D>().enabled = true;
        newEnemy.GetComponentInChildren<SpriteRenderer>().material = listEnemyPrefab[indexRandomEnemy].GetComponentInChildren<SpriteRenderer>().sharedMaterial;
        listEnemySpawned.Add(newEnemy);
    }
    private void LateUpdate()
    {
        if (count == 0)
        {
            CheckDestroyedObjects();
        }
    }
    void CheckDestroyedObjects()
    {
        //List<GameObject> destroyedObjects = new List<GameObject>();

        for (int i = 0; i < listEnemySpawned.Count; i++)
        {
            //if (listEnemySpawned[i] != null) // nay la dung de khi kiem tra Enemy da bi Destroy chua
            if (listEnemySpawned[i].activeSelf == false)
            {
                //listEnemyDie.Add(listEnemySpawned[i]);
                numberEnemyDie++;
            }
        }

        //if (destroyedObjects.Count == listEnemySpawned.Count)
        if (numberEnemyDie == listEnemySpawned.Count)
        {
            fenceToFalse.SetActive(false) ;
        }
        else
        {
            numberEnemyDie = 0;
        }
    }
}
