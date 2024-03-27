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
    private float detectionDelay = 0.05f, attackDelay = 1f, aiUpdateDeplay = 0.05f;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    bool following = false;
    [SerializeField]
    private bool returnOriginPos = true;
    public bool isComingHome = false;
    bool isAlive = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        isAlive = true;
        base.Start();
        aiEnemyMover = GetComponent<AIEnemyMover>();
        state = EnemyState.Idle;
        startPosition = transform.position;
        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);

    }
    private void Update()
    {
        if (temp != null)
        {
            if (!following)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }

        }

    }
    private void FixedUpdate()
    {
        if(isAlive)
        {
            UpdateMotor(movementInput);
        }
    }
    Transform temp;
    void PerformDetection()
    {
        if (!isComingHome) { temp = detectTarget.DetectTarget(); }


    }
    IEnumerator FinishEmptyPath()
    {
        if (!aiEnemyMover.reachedEndOfPath)
        {

            movementInput = aiEnemyMover.GetDirectionToMove();
            yield return new WaitForSeconds(aiUpdateDeplay);
            StartCoroutine(FinishEmptyPath());
        }
        else if (!temp && Vector2.Distance(transform.position, startPosition) > aiEnemyMover.targetRechedThreshold && returnOriginPos)
        {
            {
                aiEnemyMover.targetPosition = startPosition;
                aiEnemyMover.UpdatePath();
                isComingHome = true;
                yield return new WaitForSeconds(aiUpdateDeplay);
                StartCoroutine(FinishEmptyPath());
            }
        }
        else
            isComingHome = false;
    }
    void Attack()
    {
        Damage dmg = new() { damageAmount = 1, origin = transform.position, pushForce = 3 };
        temp.SendMessage("ReceivedDamage", dmg);

    }
    IEnumerator ChaseAndAttack()
    {
        if (temp == null)
        {
            print("stop");
            following = false;
            movementInput = Vector2.zero;
            FinishEmptyPath();
            StartCoroutine(FinishEmptyPath());
        }
        else
        {
            float distance = Vector2.Distance(transform.position, temp.position);

            if (distance < attackDistance)
            {
                Attack();
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
    protected override void Death()
    {
        gameObject.SetActive(false);
    }
}
    // Update is called once per frame

   
 
