using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class ChaseBehavior : StateMachineBehaviour
{
    public Rigidbody2D rb;
    protected DetectPlayer detectTarget;
    protected AIEnemyMover aiEnemyMover;
    private CoroutineRunner coroutineRunner;
    public Transform player;
    protected bool isFollowing = false;
    protected bool isComingHome = false;
    protected bool isAttacking = false;
    protected bool isAlive = true;
    protected float detectionDelay = 0.05f, aiUpdateDeplay = 0.05f;
    protected Vector2 movementInput;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        detectTarget = animator.GetComponent<DetectPlayer>();
        aiEnemyMover = animator.GetComponent<AIEnemyMover>();
        coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }
        movementInput = Vector2.zero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = detectTarget.DetectTarget();
        if (player != null)
        {
            if (!isFollowing)
            {
                isFollowing = true;
                coroutineRunner.StartCoroutine(Chasing());
            }
        }
        UpdateMotor(movementInput);
        //rb.velocity = movementInput * 0.2f;
        //Debug.Log(movementInput);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    IEnumerator Chasing()
    {
        if (player == null)
        {
            isFollowing = false;
            movementInput = Vector2.zero;
            FinishEmptyPath();
            coroutineRunner.StartCoroutine(FinishEmptyPath());
        }
        else
        {
            aiEnemyMover.targetPosition = player.position;
            aiEnemyMover.UpdatePath();
            movementInput = aiEnemyMover.GetDirectionToMove();
            yield return new WaitForSeconds(aiUpdateDeplay);
            coroutineRunner.StartCoroutine(Chasing());
            
        }
    }

    IEnumerator FinishEmptyPath()
    {
        if (!aiEnemyMover.reachedEndOfPath)
        {
            movementInput = aiEnemyMover.GetDirectionToMove();
            yield return new WaitForSeconds(aiUpdateDeplay);
            coroutineRunner.StartCoroutine(FinishEmptyPath());
        }
    }

    public virtual void UpdateMotor(Vector2 Input)
    {
        if (player != null)
        {
            if (player.position.x > rb.transform.position.x)
            {
                rb.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (player.position.x < rb.transform.position.x)
            {
                rb.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        //Ham di chuyen
        rb.velocity = Input * 0.3f;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
