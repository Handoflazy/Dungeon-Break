using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShellSelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float liveTime=2;


    private void OnEnable()
    {
        StartCoroutine(setActive());
    }
    IEnumerator setActive()
    {
        yield return new WaitForSeconds(liveTime);
        gameObject.SetActive(false);
    }

}
