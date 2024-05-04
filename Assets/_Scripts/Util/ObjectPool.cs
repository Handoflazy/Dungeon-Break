using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToSpawn;
    [SerializeField]
    protected int poolSize;
    protected int currentSize;
    protected Queue<GameObject> objectPool;


    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    public virtual GameObject SpawnObject(GameObject obj = null)
    {
        if(obj == null)
        {
            obj = objectToSpawn;
        }

        GameObject spawnedObject = null;
        if(currentSize < poolSize)
        {
            spawnedObject = Instantiate(obj, transform.position,Quaternion.identity) as GameObject;
            spawnedObject.name = obj.name +"_" + currentSize;

            currentSize++;

        }
        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
        }
        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }
}
