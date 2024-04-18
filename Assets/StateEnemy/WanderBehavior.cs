using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class WanderBehavior : StateMachineBehaviour
{
    public Rigidbody2D rb;
    Vector2 currentPos;
    protected Mover mover;
    Vector2 targetPos;
    float delayTime = 0;
    private CoroutineRunner coroutineRunner;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        currentPos = rb.transform.position;
        Debug.Log(currentPos);
        CreateRandomPos();

        coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }
    }

    private Vector2 CreateRandomPos()
    {
        float randomX = currentPos.x + Random.Range(-0.5f, 0.5f);
        float randomY = currentPos.y + Random.Range(-0.5f, 0.5f);
        targetPos = new Vector2(randomX, randomY);
        return targetPos;
    }

    IEnumerator DelayForNextPos()
    {
        yield return new WaitForSeconds(1f);
        targetPos = CreateRandomPos();
        delayTime = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delayTime += Time.deltaTime;
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, 0.5f * Time.deltaTime);
        rb.MovePosition(newPos);
        if (Vector2.Distance(rb.position, targetPos) < 0.02f || delayTime > 2f)
        {
            // Start the coroutine
            coroutineRunner.StartCoroutine(DelayForNextPos());
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
