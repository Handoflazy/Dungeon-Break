using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EarthQuake : StateMachineBehaviour
{
    private Transform playerPos;
    public GameObject earthPrefab;
    //public GameObject spellPrefab;
    public GameObject warningAreaPrefab;
    Vector2 boomPos = Vector2.zero;
    private CoroutineRunner coroutineRunner;
    public AudioSource audioSource;
    public AudioClip clipSound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }
        audioSource = animator.GetComponent<AudioSource>();

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Warning(animator);
    }

    private void Warning(Animator animator)
    {
        GameObject warningArea = Instantiate(warningAreaPrefab, animator.transform.position, Quaternion.identity);
        warningArea.transform.rotation = Quaternion.Euler(0, 0, 90);
        //GameObject spell = Instantiate(spellPrefab, playerPos.transform.position, Quaternion.identity);
        boomPos = new Vector2(playerPos.position.x, playerPos.position.y);
        coroutineRunner.StartCoroutine(AreaSkill(animator));
        Destroy(warningArea, 1f);
        audioSource.PlayOneShot(clipSound);
        //Destroy(spell, 1.2f);
    }


    IEnumerator AreaSkill(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        GameObject boom = Instantiate(earthPrefab, animator.transform.position, Quaternion.identity);
        Destroy(boom, 1f);
    }
}
