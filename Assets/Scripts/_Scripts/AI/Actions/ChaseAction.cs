using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
       var direction = enemyAIBrain.Target.transform.position - transform.position;

        aiMovementData.Direction = direction.normalized;
        aiMovementData.PointOfInterest = enemyAIBrain.Target.transform.position;
        enemyAIBrain.Move(aiMovementData.Direction,aiMovementData.PointOfInterest);
    }
}
