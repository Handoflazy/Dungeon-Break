using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonStrapper : MonoBehaviour
{
    [SerializeField]
    GameObject singletonPrefab;

    private void Awake()
    {
        if(DGSingleton.Instance !=null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instantiate(singletonPrefab);
        }
    }
}
