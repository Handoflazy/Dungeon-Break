using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject gate;
    [SerializeField]
    private GameObject fence;

    private void Update()
    {
        checkBoss();
    }

    void checkBoss()
    {
        if (boss.activeSelf == false)
        {
            gate.SetActive(true);
            fence.SetActive(false);
        }
    }
}
