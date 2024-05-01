using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData aiActionData;

    protected AIMovementData aiMovementData;
    protected EnemyAIBrain enemyAIBrain;

    private void Awake()
    {
        aiActionData = transform.root.GetComponentInChildren<AIActionData>();
        aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>();
    }
    public abstract void TakeAction();
}
