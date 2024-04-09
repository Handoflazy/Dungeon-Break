using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : Mover 
{
    [SerializeField]
     Vector3 startPos;

    [SerializeField]
    private List<SteeringBehavior> steeringBehaviors;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.03f;
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;

    [SerializeField]
    private ContextResolver movementDirectionSolver;

    bool following = false;
    protected override void Start()
    {
        base.Start();
        startPos = transform.position;

        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);
    } 
    
    private void PerformDetection()
    {
        foreach (var detector in detectors)
        {
            detector.Detect(aiData);
            
        }
       
    }
    
    private void Update()
    {
        if(aiData.currentTarget != null)
        {
            if(following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            aiData.currentTarget = aiData.targets[0];
        }
        UpdateMotor(movementInput);
    }
    
    IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            movementInput = Vector2.zero;
            following = false;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);
            if(distance < attackDistance)
            {
                movementInput = Vector2.zero;
                print("attack");
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviors, aiData);
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }
        }
    }
}
