using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAl
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        public override void Attack(int damage)
        {
           if(waitBeforeNextAttack ==false)
            {
                if (GetTarget().TryGetComponent<Damageable>(out Damageable body))
                {
                    body.DealDamage(damage,gameObject);
                }
                StartCoroutine(WaitBeforeAttackCoroutine());
            }
        }
    }
}