using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : ActorReform
{
    public EnemyStatsSO statsData;
    public PlayerEvents playerEvents;

    public UnityEvent<Vector2> OnPointerPositionChange;

    [field:SerializeField]
    public EnemyAttack EnemyAttack {  get; set; }

    [field:SerializeField]
    public AIState CurrentState { get; set; }
    public bool Dead { get => dead; set => dead = value; }

    public GameObject Target;

    private bool dead = false;
    internal void ChangeToState(AIState state)
    {
        CurrentState = state;
    }
    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
        if (!EnemyAttack)
        {
            EnemyAttack = GetComponent<EnemyAttack>();
        }
    }

    Player playerScript;
    void Start()
    {
        playerScript = Target.GetComponent<Player>();
        UpdateStatsByPlayer();
    }
    private void Update()
    {
        if(Target == null)
        {
            playerEvents.OnMove?.Invoke(Vector2.zero);
        }
        if(CurrentState)
            CurrentState.UpdateState();
    }

    public void Attack()
    {
        if (Dead == false&&EnemyAttack)
        {
            playerEvents.OnPressed?.Invoke();
            EnemyAttack.Attack(statsData.damage);
        }
    }

    public void RangeAttack(GameObject bulletPrefab, int numberOfBullets)
    {
        if (Dead == false&&EnemyAttack)
        {
            playerEvents.OnPressed?.Invoke();
            EnemyAttack.RangeAttack(bulletPrefab, numberOfBullets);
        }
    }
    public void RangeAttackV2(GameObject bulletPrefab, int numberOfBullets)
    {
        if (Dead == false && EnemyAttack)
        {
            playerEvents.OnPressed?.Invoke();
            EnemyAttack.RangeAttackV2(bulletPrefab, numberOfBullets);
        }
    }

    public void Move(Vector2 movementDirection, Vector2 targetPosition)
    {
        playerEvents.OnMove?.Invoke(movementDirection);
       OnPointerPositionChange?.Invoke(targetPosition);
    }

    private void UpdateStatsByPlayer()
    {
        if (Target && !gameObject.CompareTag("BossForest") && !gameObject.CompareTag("BossGra"))
        {
            statsData.minXpBonus += Mathf.Max(0, playerScript.playerStats.level * (playerScript.playerStats.levelUpXpRequire / (playerScript.playerStats.levelUpXpRequire - playerScript.playerStats.levelUpXpRequireUp)));
            statsData.maxXpBonus += Mathf.Max(0, playerScript.playerStats.level * (playerScript.playerStats.levelUpXpRequire / (playerScript.playerStats.levelUpXpRequire - playerScript.playerStats.levelUpXpRequireUp)));
            statsData.damage += playerScript.playerStats.level / 10;
            statsData.hp += playerScript.playerStats.level / 5;
        }
    }
}
