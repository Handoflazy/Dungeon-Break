using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [field: SerializeField, Range(0.1f, 10f)]
    public float Distance { get; set; }
    public override bool MakeDecision()
    {
        if (Vector3.Distance(enemyAIBrain.Target.transform.position, transform.position) < Distance)
        {
            if (aiActionData.TargetSpotted == false)
            {
                aiActionData.TargetSpotted = true;
            }
        }
        else
        {
            aiActionData.TargetSpotted = false;

        }
        return aiActionData.TargetSpotted;
    }
    protected void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,Distance);
            Gizmos.color = Color.white;
        }
    }
}
