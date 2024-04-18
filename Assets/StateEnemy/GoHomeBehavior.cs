using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoHomeBehavior : StateMachineBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 spawnPos;
    protected CoroutineRunner coroutineRunner;
    protected AIEnemyMover aiEnemyMover;
    protected AIEnemy aiEnemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coroutineRunner = animator.GetComponent<CoroutineRunner>();
        aiEnemyMover = animator.GetComponent<AIEnemyMover>();
        aiEnemy = animator.GetComponent<AIEnemy>();
        rb = animator.GetComponent<Rigidbody2D>();
        //Lay vi tri spawn cua enemy
        spawnPos = aiEnemy.startPosition;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GoHome();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    protected void GoHome()
    {
        aiEnemyMover.targetPosition = spawnPos;
        aiEnemyMover.UpdatePath();
        Vector2 movementInput = aiEnemyMover.GetDirectionToMove();
        //Ham di chuyen
        rb.velocity = movementInput * 0.2f;
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
