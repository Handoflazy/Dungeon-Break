using UnityEngine;
using System.Collections.Generic;

public class Gate : MonoBehaviour
{
    public List<Transform> gateDestinations; // Danh sách các vị trí đích của các cánh cổng
    public Transform player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //MovePlayerToRandomDestination();
        Debug.Log("ma cha may co dung dc ko");
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") ||collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            MovePlayerToRandomDestination();
        }
    }

    private void MovePlayerToRandomDestination()
    {
        Debug.LogWarning("Không có đích nào được cấu hình cho cánh cổng này.");
        int randomIndex = Random.Range(0, gateDestinations.Count);
        Transform destination = gateDestinations[randomIndex];
        // Di chuyển player đến vị trí đích ngẫu nhiên
        player.transform.position = destination.position;
        
            
        
    }
}
