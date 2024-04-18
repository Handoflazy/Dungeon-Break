using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Skull_Follow : StateMachineBehaviour
{
    private Transform playerPos;
    public float moveSpeed = 5f;
    public GameObject boomPrefab;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 direction = (playerPos.position - animator.transform.position).normalized;

        animator.transform.position += direction * moveSpeed * Time.deltaTime;
        if (playerPos.position.x > animator.transform.position.x)
        {
            animator.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (playerPos.position.x < animator.transform.position.x)
        {
            animator.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if ((Mathf.Abs(playerPos.position.x - animator.transform.position.x) <= 0.15f) && (Mathf.Abs(playerPos.position.y - animator.transform.position.y) <= 0.15f))
        {
            GameObject boom = Instantiate(boomPrefab, animator.transform.position, Quaternion.identity);
            Destroy(boom, 1f);
            Destroy(animator.gameObject);
        }
        Destroy(animator.gameObject, 15f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
