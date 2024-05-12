using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerRandom : ObjectPool
{
    //[SerializeField]
    //private GameObject enemyPrefab;
    [SerializeField]
    private List<GameObject> spawnPoints;
    [SerializeField]
    private int count = 20;
    //public GameObject fence;
    public List<GameObject> listEnemyPrefab;
    [SerializeField]
    private float minDelay = .8f, maxDelay = 1.5f;
    private int indexRandomEnemy;

    private void Start()
    {
        if (spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint.transform.position);
            }
        }
        StartCoroutine(SpawnCoroutine());
    }
    IEnumerator SpawnCoroutine()
    {
        while (count > 0)
        {
            count--;
            var randomIndex = Random.Range(0, spawnPoints.Count);
            var randomOffset = Random.insideUnitCircle * 0.16f;
            indexRandomEnemy = Random.Range(0, listEnemyPrefab.Count);

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

        GameObject newEnemy = SpawnObject(listEnemyPrefab[indexRandomEnemy]);
        newEnemy.SetActive(true);
        newEnemy.transform.position = spawnPoint;
        newEnemy.transform.rotation = listEnemyPrefab[indexRandomEnemy].transform.rotation;
        newEnemy.GetComponent<CapsuleCollider2D>().enabled = true;
        newEnemy.GetComponentInChildren<SpriteRenderer>().material = listEnemyPrefab[indexRandomEnemy].GetComponentInChildren<SpriteRenderer>().sharedMaterial;
    }
}
