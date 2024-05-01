using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
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

    public abstract bool MakeDecision();
}
