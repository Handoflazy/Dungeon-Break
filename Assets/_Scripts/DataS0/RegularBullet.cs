using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rb;

    private bool isDead = false;
    private ObstacleImpactGenerator obstacleImpactGenerator;

    [SerializeField]
    protected LayerMask ObstacleLayers,DamageableLayers;

    private void OnEnable()
    {
        isDead = false;
    }

    public override BulletDataSO BulletData 
    { get => base.BulletData;
        set { 
            base.BulletData = value;
            rb = GetComponent<Rigidbody2D>();
            rb.drag = BulletData.Friction;
        }
    }
    private void FixedUpdate()
    {
        if(rb != null && BulletData)
        {
            rb.MovePosition(transform.position + bulletData.BulletSpeed * transform.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDead&&bulletData.GoThrougHitable==false) return;
        isDead = true;
        if((ObstacleLayers & (1<<collision.gameObject.layer))!=0)
        {
            HitObstacle(collision.gameObject);
        }
        if((DamageableLayers & (1 << collision.gameObject.layer)) != 0)
        {
            HitEnemy(collision.gameObject);
        }
        gameObject.SetActive(false);
    }

    private void HitEnemy(GameObject enemy)
    {
        Vector2 randomOffset = Random.insideUnitCircle * 0.05f;
       
        if (enemy.TryGetComponent<Damageable>(out Damageable component))
        {
            component.DealDamage(BulletData.Damage, transform.root.gameObject);
            Instantiate(BulletData.ImpactEnemyPrefab, enemy.transform.position+(Vector3)randomOffset, Quaternion.identity);
            if(enemy.TryGetComponent<Knockable>(out Knockable knockable))
            {
                knockable.KnockBack(transform.right, bulletData.KnockBackPower, bulletData.KnockBackDelay);
            }
        }
        else
        {
            Instantiate(BulletData.ImpactObstaclePrefab, enemy.transform.position + (Vector3)randomOffset, Quaternion.identity);
        }
    }
    private void HitObstacle(GameObject obstacle)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if(hit.collider!= null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
        
    }

}
