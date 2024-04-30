using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rb;
    [SerializeField]
    protected LayerMask ObstacleLayers;

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
        if((ObstacleLayers & (1<<collision.gameObject.layer))!=0)
        {
            if (collision.TryGetComponent<Damageable>(out Damageable component))
            {
                component.DealDamage(BulletData.Damage, gameObject);
            }
        }
        Destroy(gameObject);
    }
    private void HitObstacle()
    {
        
        if(TryGetComponent<Damageable>(out Damageable component))
        {
            component.DealDamage(BulletData.Damage, transform.root.gameObject);
        }
    }

}
