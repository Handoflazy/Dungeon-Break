using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField, Range(0.16f, 3)]
    private float distance = 3;
    [SerializeField]
    private LayerMask raycastMask = new LayerMask();
    [field:SerializeField]
    public UnityEvent OnPlayerSpotted { get;set; }
    public override bool MakeDecision()
    {
        var direction = enemyAIBrain.Target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,distance,raycastMask);
        if( hit.collider != null)
        {
            
            if(hit.collider&&hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")){
                OnPlayerSpotted?.Invoke();
                return true;
            }
        }
        return false;
        
    }
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject==gameObject) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,distance);
            Gizmos.color = Color.white;
        }
    }

}
