using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackAction : AIAction
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 10;
    public override void TakeAction()
    {
        //print(Vector2.Distance(transform.parent.position, enemyAIBrain.Target.transform.position));
        aiMovementData.Direction = Vector3.zero;
        aiMovementData.PointOfInterest = enemyAIBrain.Target.transform.position;
        enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        aiActionData.Attack = true;
        enemyAIBrain.RangeAttack(bulletPrefab, numberOfBullets);
    }
}
