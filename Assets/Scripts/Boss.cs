using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Boss : Enemy
{
    // Start is called before the first frame update
    public GameObject minionPrefab;
    private readonly Vector3[] posMobs = { new(-0.25f, -0.2f, 0), new (-0.25f, 0.2f, 0), new (0.25f, -0.23f, 0), new (0.25f, 0.22f, 0) };
    private List<GameObject> listMinion;
    private int healingAmount;
    private float lastTime;
    private float coolDown =4.0f;

    protected override void Start()
    {
        base.Start();  
        listMinion = new List<GameObject>();
        for (int i = 0; i < posMobs.Length; i++)
        {
            GameObject obj = Instantiate(minionPrefab, posMobs[0],Quaternion.identity,this.transform);
            obj.transform.localPosition = posMobs[i];
            obj.GetComponent<Enemy>().SetStaringPos(obj.transform.localPosition);
            obj.SetActive(false);
            listMinion.Add(obj);
        }
        lastTime = 0;
    }
    private void ResetState()
    {
        foreach(GameObject obj in listMinion)
        {
            obj.SetActive(false);
            hitPoint = maxHitPoint;
        }
    }
    IEnumerator Healing()
    {
        while(transform.position == startingPostion && hitPoint < maxHitPoint)
        {
            hitPoint += healingAmount;
            if (hitPoint >= maxHitPoint)
            {
                ResetState(); break;
            }
            yield return new WaitForSeconds(1);
        }
    }
  
    public GameObject GetEnemyObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < listMinion.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!listMinion[i].activeInHierarchy)
            {
                return listMinion[i];
            }
        }
        // otherwise, return null   
        return null;

    }
    private void Update()
    {
        
        if(transform.position == startingPostion)
        {
            StartCoroutine(Healing());
        }
        if (chasing)
        {
            if(Time.time - coolDown > lastTime)
            {
                lastTime = Time.time;
                GameObject Enemy = GetEnemyObject();
                if (Enemy != null)
                {
                    Enemy.SetActive(true);
                }
            }
        }
    }
}
