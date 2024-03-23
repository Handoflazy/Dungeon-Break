using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : Detector
{
    [SerializeField]
    private float detectorRadius = 2;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private bool showGizmoz = true;

    Collider2D[] colliders;

    public override void Detect(AIData aiData)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position,detectorRadius,layerMask);
        aiData.obstacles = colliders;
    }
    private void OnDrawGizmos()
    {
        if(showGizmoz ==false) return;

        if(Application.isPlaying &&colliders != null)
        {
            Gizmos.color = Color.red;

            foreach(Collider2D obstacleCollider in colliders)
            {
              
                Gizmos.DrawSphere(obstacleCollider.ClosestPoint(transform.position), 0.05f);
            }
        }
    }
}
 
