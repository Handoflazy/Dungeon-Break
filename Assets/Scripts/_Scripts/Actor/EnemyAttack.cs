using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyAIBrain enemyAIBrain;

    [field: SerializeField]
    public float AttackDelay { set; private get; } = 1;

    protected bool waitBeforeNextAttack;

    private void Awake()
    {
        enemyAIBrain = GetComponent<EnemyAIBrain>();
    }
    public abstract void Attack(int damage);
    public abstract void RangeAttack(GameObject bulletPrefab, int numberOfBullets);


    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeNextAttack = false;
    }

    protected GameObject GetTarget()
    {
        return enemyAIBrain.Target;
    }
}
