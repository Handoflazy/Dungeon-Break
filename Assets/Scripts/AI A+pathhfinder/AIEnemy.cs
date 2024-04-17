using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;
using UnityEngine.Events;

public class AIEnemy : MonoBehaviour
{
    [Header("AIEnemy")]
    public EnemyState state;
    public Vector2 startPosition;
    private AIEnemyMover aiEnemyMover;
    [SerializeField]
    private DetectPlayer detectTarget;

    private Flash flash;
    [Header("AI Setting")]
    [SerializeField]
    private float detectionDelay = 0.05f, attackDelay = 1f, aiUpdateDeplay = 0.05f;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    [SerializeField]
    private bool returnOriginPos = true;
    public bool isComingHome = false;
    bool isAlive = true;

    [Header("Other Reference")]
    [SerializeField]
    public UnityEvent<Vector2> MovementInput;
    public UnityEvent OnDeathEvent;



    protected  void Awake()
    {
        
        flash = transform.GetChild(0).GetComponent<Flash>();
        aiEnemyMover = GetComponent<AIEnemyMover>(); 
    }

    protected void Start()
    {
        isAlive = true;
        state = EnemyState.Idle;
        startPosition = transform.position;
        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);

    }
    private void Update()
    {
        if (playerTransform != null)
        {
            if (state != EnemyState.Chasing)
            {
                state = EnemyState.Chasing;
                StartCoroutine(ChaseAndAttack());
            }

        }

    }
    private void FixedUpdate()
    {
        if(isAlive)
        {
            MovementInput?.Invoke(movementInput);
        }
    }
    Transform playerTransform;
    void PerformDetection()
    {
        if (!isComingHome) { playerTransform = detectTarget.DetectTarget(); }
    }
    IEnumerator FinishEmptyPath()
    {
        if (!aiEnemyMover.reachedEndOfPath)
        {

            movementInput = aiEnemyMover.GetDirectionToMove();
            yield return new WaitForSeconds(aiUpdateDeplay);
            StartCoroutine(FinishEmptyPath());
        }
        else if (!playerTransform && Vector2.Distance(transform.position, startPosition) > aiEnemyMover.targetRechedThreshold && returnOriginPos)
        {
            {
                aiEnemyMover.targetPosition = startPosition;
                aiEnemyMover.UpdatePath();
                isComingHome = true;
                yield return new WaitForSeconds(aiUpdateDeplay);
                StartCoroutine(FinishEmptyPath());
            }
        }
        else
            isComingHome = false;
    }

    void Attack()
    {
        Damage dmg = new() { damageAmount = 5, origin = transform.position, pushForce = 1 };
        if (playerTransform.gameObject.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(dmg, this.gameObject);
        }
        else
        {
            Debug.Log("That object cannot be damaged.");
        }
    }
    IEnumerator ChaseAndAttack()
    {
        if (playerTransform == null)
        {
            state = EnemyState.Idle;
            movementInput = Vector2.zero;
            FinishEmptyPath();
            StartCoroutine(FinishEmptyPath());
        }
        else
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < attackDistance)
            {
                Attack();
                movementInput = Vector2.zero;
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                aiEnemyMover.targetPosition = playerTransform.position;
                aiEnemyMover.UpdatePath();
                movementInput = aiEnemyMover.GetDirectionToMove();
                yield return new WaitForSeconds(aiUpdateDeplay);
                StartCoroutine(ChaseAndAttack());

            }
        }
    }
    public void Death()
    {
        StartCoroutine(SecondBeforeFade());
  
    }
    public IEnumerator SecondBeforeFade()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        OnDeathEvent?.Invoke();
        
    }
   
}
    // Update is called once per frame

   
 
