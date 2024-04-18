using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spell : StateMachineBehaviour
{
    private Transform playerPos;
    public GameObject boomPrefab;
    public GameObject spellPrefab;
    public GameObject warningAreaPrefab;
    Vector2 boomPos = Vector2.zero;
    private CoroutineRunner coroutineRunner;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }

        
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExplosionSkill(animator);
    }

    private void ExplosionSkill(Animator animator)
    {
        GameObject warningArea = Instantiate(warningAreaPrefab, playerPos.transform.position, Quaternion.identity);
        GameObject spell = Instantiate(spellPrefab, playerPos.transform.position, Quaternion.identity);
        boomPos = new Vector2(playerPos.position.x, playerPos.position.y);
        coroutineRunner.StartCoroutine(AreaSkill(animator));
        Destroy(warningArea, 1f);
        Destroy(spell, 1.2f);
    }


    IEnumerator AreaSkill(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        GameObject boom = Instantiate(boomPrefab, boomPos, Quaternion.identity);
        Destroy(boom, 1f);
    }
}
