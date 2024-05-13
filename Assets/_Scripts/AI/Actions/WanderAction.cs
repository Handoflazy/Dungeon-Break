using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAction : AIAction
{
    protected Vector2 spawnPosition;
    public override void TakeAction()
    {
        Vector2 wanderOffset = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
        Vector2 wanderPos = spawnPosition + wanderOffset;
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = transform.position;
        enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);

    }
}
