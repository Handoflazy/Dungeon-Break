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

        public override void RangeAttack(GameObject bulletPrefab, int numberOfBullets)
        {
            if (enemyAIBrain.Target.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (enemyAIBrain.Target.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (waitBeforeNextAttack ==false)
            {
                float maxScatterAngle = (numberOfBullets - 1) * 10;
                // Tính góc giữa các viên đạn
                float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;
                float initialScatterAngle = -maxScatterAngle;
                float bulletSpacing = 0f;
                for (int i = 0; i < numberOfBullets; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    if(bullet.TryGetComponent<EnemyBullet>(out EnemyBullet bulletBullet))
                    {
                        bulletBullet.Damage = enemyAIBrain.statsData.damage;
                    }

                    Vector3 lookDirection = (enemyAIBrain.Target.transform.position - transform.position).normalized;
                    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.velocity = bullet.transform.right;
                    initialScatterAngle += angleBetweenBullets;
                    bullet.transform.position += bullet.transform.right * (bulletSpacing);
                    //Destroy(bullet, 3f);
                    Destroy(bullet, 3f);
                }

                StartCoroutine(WaitBeforeAttackCoroutine());
            }
        }
    }
}