using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Gate : MonoBehaviour
{
    public List<Transform> gateDestinations;
    public Transform player;
    public float lockTime = 2f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") ||collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            MovePlayerToRandomDestination();
        }
    }

    private void MovePlayerToRandomDestination()
    {
        int randomIndex = Random.Range(0, gateDestinations.Count);
        Transform destination = gateDestinations[randomIndex];
        player.transform.position = destination.position;
        StartCoroutine(LockGate(destination));
    }
    IEnumerator LockGate(Transform destination)
    {
        destination.gameObject.SetActive(false); 
        yield return new WaitForSeconds(lockTime);
        destination.gameObject.SetActive(true); 
    }
}
