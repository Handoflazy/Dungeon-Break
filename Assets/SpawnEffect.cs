using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    public GameObject spawnEffect;
    private bool isSpawn = true;
    public float Y = 0.3f;
    private void Update()
    {
        if(isSpawn == true)
        {
            GameObject spawn = Instantiate(spawnEffect, transform.position, Quaternion.identity);
            spawn.transform.position = new Vector3(transform.position.x, transform.position.y + Y, transform.position.z);
            Destroy(spawn, 0.5f);
            isSpawn = false;

        }
        
    }

}
