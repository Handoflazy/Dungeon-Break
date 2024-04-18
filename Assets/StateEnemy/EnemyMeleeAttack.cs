using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class EnemyMeleeAttack : StateMachineBehaviour
{
    protected DetectPlayer detectTarget;
    public Transform player;
    public float moveSpeed = 15f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        detectTarget = animator.GetComponent<DetectPlayer>();
        player = detectTarget.DetectTarget();
        if (player != null)
        {
            if (player.position.x > animator.transform.position.x)
            {
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (player.position.x < animator.transform.position.x)
            {
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            Vector3 direction = (player.position - animator.transform.position).normalized;
            Vector3 targetPosition = animator.transform.position + direction*5;
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

 
}
