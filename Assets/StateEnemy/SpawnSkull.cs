using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSkull : StateMachineBehaviour
{

    public GameObject skullPrefab;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SkullFollow(animator);
    }

    private void SkullFollow(Animator animator)
    {
        GameObject skull = Instantiate(skullPrefab, animator.transform.position, Quaternion.identity);
    }

}
