using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpawnEnemy : MonoBehaviour
{
    public GameObject spawnEnemy;
    public GameObject fence;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            spawnEnemy.SetActive(true);
            fence.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            spawnEnemy.SetActive(false);
        }
    }
}
