using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class SkillBossForest : StateMachineBehaviour
{
/*    public Transform firepoint;
    private Transform playerPos;
    public GameObject bulletPrefab;
    public GameObject boomPrefab;
    public GameObject spellPrefab;
    public GameObject skullPrefab;
    public GameObject warningAreaPrefab;
    //public GameObject[] enemyPrefab;
    public float spawnRadius = 0.2f;

    public int numberOfBullets = 10;
    Vector2 boomPos = Vector2.zero;*/

    [SerializeField]
    private float timeSinceComboBullet = 0f;
    [SerializeField]
    private float timeSinceDef = 0f;
    [SerializeField]
    private float timeSinceEarthQuake = 0f;
    [SerializeField]
    private float timeSinceUlti = 8f;

    public float coldownCombo = 3f;
    public float coldownDef = 5f;
    public float coldownEarthQuake = 7f;
    public float coldownUlti = 17f;

    public Rigidbody2D rb;
    protected DetectPlayer detectTarget;
    public Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;*/
        detectTarget = animator.GetComponent<DetectPlayer>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = detectTarget.DetectTarget();
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

        timeSinceComboBullet += Time.deltaTime;
        timeSinceDef += Time.deltaTime;
        timeSinceEarthQuake += Time.deltaTime;
        timeSinceUlti += Time.deltaTime;

        if (timeSinceComboBullet >= coldownCombo)
        {
            animator.SetTrigger("ComboBullet");
            timeSinceComboBullet = 0f;
        }
        if (timeSinceDef >= coldownDef)
        {
            animator.SetTrigger("Def");
            timeSinceDef = 0f;
        }
        if (timeSinceEarthQuake >= coldownEarthQuake)
        {
            animator.SetTrigger("EarthQuake");
            timeSinceEarthQuake = 0f;
        }
        if (timeSinceUlti >= coldownUlti)
        {
            animator.SetTrigger("Ulti");
            timeSinceUlti = 0f;
        }


        
    }

}
