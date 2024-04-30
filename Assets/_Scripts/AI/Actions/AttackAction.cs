using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector3.zero;
        aiMovementData.PointOfInterest = enemyAIBrain.Target.transform.position;
        enemyAIBrain.Move(aiMovementData.Direction,aiMovementData.PointOfInterest);
        aiActionData.Attack = true;
        enemyAIBrain.Attack();
    }
}
