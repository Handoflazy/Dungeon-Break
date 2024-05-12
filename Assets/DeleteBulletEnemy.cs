using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBulletEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Blocking") || collision.gameObject.layer == LayerMask.NameToLayer("Blocking")) 
        {
            Destroy(gameObject);
        }
    }
}
