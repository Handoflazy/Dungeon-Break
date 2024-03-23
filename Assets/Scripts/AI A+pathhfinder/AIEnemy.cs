using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class AIEnemy : Mover
{
    [Header("AIEnemy")]
    public EnemyState state;
    public Vector2 startPosition;
    private AIEnemyMover aiEnemyMover;
    [SerializeField]
    private DetectPlayer detectTarget;
    [SerializeField]
    private float detectionDelay = 0.05f, attackDelay = 1f,aiUpdateDeplay = 0.05f;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    bool following = false;

    // Start is called before the first frame update
    protected override void Start()
    {
       aiEnemyMover = GetComponent<AIEnemyMover>();
        state = EnemyState.Idle;
        startPosition = transform.position;
        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);

    }
    private void Update()
    {
        if(temp!=null)
        {
            if (!following)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
          
        }
        UpdateMotor(movementInput);
    }
    Transform temp;
    void PerformDetection()
    {
        temp =  detectTarget.DetectTarget();
   
    }
    IEnumerator FinishEmptyPath()
    {
        if (!aiEnemyMover.reachedEndOfPath)
        {

            movementInput = aiEnemyMover.GetDirectionToMove();
            yield return new WaitForSeconds(aiUpdateDeplay);
            StartCoroutine(FinishEmptyPath());
        }
        else if (Vector2.Distance(transform.position,startPosition)>aiEnemyMover.targetRechedThreshold)
        {
            {
                aiEnemyMover.targetPosition = startPosition;
                aiEnemyMover.UpdatePath();
                yield return new WaitForSeconds(aiUpdateDeplay);
                StartCoroutine(FinishEmptyPath());
            }
        }
    }
   
    IEnumerator ChaseAndAttack()
    {
        if(temp == null) {
            print("stop");
            following = false;
            movementInput = Vector2.zero;
            StartCoroutine(FinishEmptyPath());
        }
        else
        {
            float distance = Vector2.Distance(transform.position,temp.position);
         
            if(distance< attackDistance)
            {
                print("attack");
                movementInput = Vector2.zero;
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                aiEnemyMover.targetPosition = temp.position;
                aiEnemyMover.UpdatePath();
                movementInput = aiEnemyMover.GetDirectionToMove();
                yield return new WaitForSeconds(aiUpdateDeplay);
                StartCoroutine(ChaseAndAttack());

            }
        }
    }
    // Update is called once per frame

   
 
}
