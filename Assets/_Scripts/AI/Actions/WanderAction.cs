using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WanderAction : AIAction
{
    protected Vector2 spawnPosition;
    private bool reachDestination = false;


    private void Start()
    {
        spawnPosition = transform.position;
    }


    public override void TakeAction()
    {
        print(reachDestination);
        if (!reachDestination)
        {
            Vector2 wanderOffset = new Vector2(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f));
            Vector2 wanderPos = spawnPosition + wanderOffset;
            aiMovementData.Direction = wanderPos - (Vector2)transform.position;
            aiMovementData.PointOfInterest = wanderPos;
            enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
            reachDestination = true;
        }
    }

    private void WanderPos()
    {
        Vector2 wanderOffset = new Vector2(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f));
        Vector2 wanderPos = spawnPosition + wanderOffset;
        aiMovementData.Direction = wanderPos - (Vector2)transform.position;
        aiMovementData.PointOfInterest = wanderPos;
        enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
