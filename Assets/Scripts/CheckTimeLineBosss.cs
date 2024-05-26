using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeLineBoss : MonoBehaviour
{
    public GameObject timeline;
    public GameObject fence;
    public GameObject boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            timeline.SetActive(true);
            fence.SetActive(true);
        }
    }
    private void Update()
    {
        if (boss.activeSelf == false) 
        {
            fence.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
