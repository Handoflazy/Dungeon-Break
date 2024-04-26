using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;
using UnityEngine.Events;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class AIEnemy : MonoBehaviour
{
    [Header("AIEnemy")]
    public EnemyState state;
    public Vector2 startPosition;
    private AIEnemyMover aiEnemyMover;
    [SerializeField]
    private DetectPlayer detectTarget;

    //private Flash flash;
    [Header("AI Setting")]
    [SerializeField]
    private float detectionDelay = 0.5f, aiUpdateDeplay = 0.5f; //attackDelay = 1f,
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    [SerializeField]
    private bool returnOriginPos = true;
    public bool isComingHome = false;
    bool isAlive = true;

    private Animator anim;
    Transform targetPlayer;
    //Kiem soat thoi gian o trang thai idle
    [SerializeField]
    float idleTime = 0f;
    //Trang thai hien tai
    public EnemyState currentState;

    [Header("Other Reference")]
    [SerializeField]
    public UnityEvent<Vector2> MovementInput;
    public UnityEvent OnDeathEvent;

    //Quan ly State cua enemy
    public enum EnemyState
    {
        Idle,
        Chasing,
        Wander,
        Attack,
        GoHome
    }
    protected void Awake()
    {

        //flash = transform.GetChild(0).GetComponent<Flash>();
        aiEnemyMover = GetComponent<AIEnemyMover>();

    }

    protected void Start()
    {
        isAlive = true;
        state = EnemyState.Idle;
        startPosition = transform.position;
        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        idleTime += Time.deltaTime;
        CheckState();
        //if (targetPlayer != null)
        //{
        //    if (state != EnemyState.Chasing)
        //    {
        //        state = EnemyState.Chasing;
        //        //StartCoroutine(ChaseAndAttack());
        //    }

        //}
    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            MovementInput?.Invoke(movementInput);
        }
        
    }

    void PerformDetection()
    {
        if (!isComingHome) { targetPlayer = detectTarget.DetectTarget(); }
    }


    public void Death()
    {
        //StartCoroutine(SecondBeforeFade());

    }
    //public IEnumerator SecondBeforeFade()
    //{
    //    yield return new WaitForSeconds(flash.GetRestoreMatTime());
    //    OnDeathEvent?.Invoke();

    //}

    //IEnumerator UpdateState()
    //{

    //    while (true)
    //    {
    //        // Kiểm tra trạng thái mới
    //        CheckState();

    //        // Chờ một khoảng thời gian trước khi kiểm tra lại
    //        yield return new WaitForSeconds(stateCheckInterval);
    //    }
    //}

    void CheckState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Wander:
                Wander();
                break;
            case EnemyState.Chasing:
                Chasing();
                break;
            case EnemyState.GoHome:
                GoHome();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                break;
        }
    }


    void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    void Idle()
    {
        if (targetPlayer != null)
        {
            if (targetPlayer.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (targetPlayer.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Vector2.Distance(targetPlayer.position, transform.position) > attackDistance)
            {
                ChangeState(EnemyState.Chasing);
            }
            else
            {
                ChangeState(EnemyState.Attack);
            }
        }
        else if (idleTime >= 5f)
        {
            ChangeState(EnemyState.Wander);
        }
    }
    void Wander()
    {
        anim.SetBool("isGoingHome", false);
        anim.SetBool("isChasing", false);
        anim.SetBool("isWandering", true);
        if (targetPlayer != null)
        {
            ChangeState(EnemyState.Chasing);
        }
    }

    void Chasing()
    {
        anim.SetBool("isGoingHome", false);
        anim.SetBool("isWandering", false);
        anim.SetBool("isChasing", true);
        if (targetPlayer != null && Vector2.Distance(transform.position, targetPlayer.position) <= attackDistance)
        {
            ChangeState(EnemyState.Attack);
            return;
        }
        if (!aiEnemyMover.reachedEndOfPath)
        {
            movementInput = aiEnemyMover.GetDirectionToMove();
            //yield return new WaitForSeconds(aiUpdateDeplay);
            //StartCoroutine(FinishEmptyPath());
        }
        else if (targetPlayer == null && Vector2.Distance(transform.position, startPosition) > aiEnemyMover.targetRechedThreshold && returnOriginPos)
        {
            ChangeState(EnemyState.GoHome);
        }

    }

    void GoHome()
    {
        anim.SetBool("isWandering", false);
        anim.SetBool("isChasing", false);
        anim.SetBool("isGoingHome", true);
        if (targetPlayer != null)
        {
            ChangeState(EnemyState.Chasing);
        }
        else if (Vector2.Distance(transform.position, startPosition) <= 0.16f)
        {
            ChangeState(EnemyState.Wander);
        }
    }

    void Attack()
    {
        anim.SetBool("isWandering", false);
        anim.SetBool("isChasing", false);
        anim.SetBool("isGoingHome", false);
        anim.SetTrigger("Attack");

        ChangeState(EnemyState.Idle);
        //if (targetPlayer != null && Vector2.Distance(targetPlayer.position, transform.position) > attackDistance)
        //{
        //    ChangeState(EnemyState.Chasing);
        //}
    }
}


