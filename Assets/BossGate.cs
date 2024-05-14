using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosGate : MonoBehaviour
{
    public GameObject HPBossBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") ||collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            HPBossBar.gameObject.SetActive(true);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") ||collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
    //    {
    //        HPBossBar.gameObject.SetActive(false);
    //    }
    //}
}
