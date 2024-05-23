using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BosGate : MonoBehaviour
{
    public GameObject HPBarToTrue;
    //public GameObject HPBarToFalse;
    public UnityEvent OnPlayerEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") ||collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            OnPlayerEnter?.Invoke();
            HPBarToTrue.gameObject.SetActive(true);
            // HPBarToFalse.gameObject.SetActive(false);
            Destroy(gameObject,1);
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
