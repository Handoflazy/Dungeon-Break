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
            if (!aiActionData.TargetSpotted)  // Using "!" for negation
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
        // Removed reference to Selection.activeObject
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Distance);
        Gizmos.color = Color.white;
    }
}
