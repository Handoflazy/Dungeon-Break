using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public float timeSpawn=3.0f;
    // Start is called before the first frame update
   
    IEnumerator spawnEnemt()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            GameObject enemy = EnemyBool.SharedInstance.GetPooledObject();
            if (enemy != null)
            {
               
                enemy.SetActive(true);
            }
        }
    }
    private void Start()
    {
        StartCoroutine(spawnEnemt());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
