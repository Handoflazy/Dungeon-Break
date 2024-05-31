using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rb;

    private bool isDead = false;
    private float flyDistance = 1;

    [SerializeField]
    protected LayerMask ObstacleLayers,DamageableLayers;

    protected void OnEnable()
    {
        isDead = false;
        flyDistance = 0;
    }

    public override BulletDataSO BulletData 
    { get => base.BulletData;
        set { 
            base.BulletData = value;
            rb = GetComponent<Rigidbody2D>();
            rb.drag = BulletData.Friction;
        }
    }
    protected void FixedUpdate()
    {
        if (rb != null && BulletData)
        {
            rb.MovePosition(transform.position + bulletData.BulletSpeed * transform.right * Time.deltaTime);
            flyDistance += Time.deltaTime * bulletData.BulletSpeed;
        }
        CheckFlyDistance();
    }

    protected void CheckFlyDistance()
    {
        if (flyDistance >= bulletData.FlyDistance)
        {
            gameObject.SetActive(false);
            Instantiate(BulletData.ImpactObstaclePrefab,transform.position, Quaternion.identity);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
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

    protected void HitEnemy(GameObject enemy)
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
    protected void HitObstacle(GameObject obstacle)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if(hit.collider!= null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
        
    }

}
