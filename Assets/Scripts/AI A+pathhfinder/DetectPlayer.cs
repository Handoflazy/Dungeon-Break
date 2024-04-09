using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    private float targetDetectionRange = 5;
    [SerializeField]
    private LayerMask obstacleLayerMask, playerLayerMask;

    [SerializeField]
    private bool showGizmos = false;

    private Transform targetPlayer;
    
    public Transform DetectTarget()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, targetDetectionRange, playerLayerMask);
        if (playerCollider != null)
        {
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, targetDetectionRange);
            if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
            {

                Debug.DrawRay(transform.position, direction * targetDetectionRange, Color.magenta);
                targetPlayer = playerCollider.transform;
                
            }
            else
            {
                targetPlayer= null;
            }
        }
        else
        {
            targetPlayer = null;
        }
        return targetPlayer;
    }

    private void OnDrawGizmosSelected()
    {
        if (showGizmos == false)
        {
            return;
        }
        Gizmos.DrawWireSphere(transform.position, targetDetectionRange);
        if (targetPlayer == null)
        {
            return;
        }
        Gizmos.color = Color.red;
       
        Gizmos.DrawSphere(targetPlayer.position, 0.05f);
        
    }
}
