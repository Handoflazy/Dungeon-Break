using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MineController : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip activeSound;
    //[SerializeField]
    //private AudioClip explosionSound;

    private MineDataSO mineData;

    public MineDataSO MineData { get => mineData; set => mineData=value; }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = MineData.MineImage;
        StartCoroutine(WaitForExplosion());
    }


    protected IEnumerator WaitForExplosion()
    {
        yield return new WaitForSeconds(MineData.WaitTime);
        Explosion();
    }

    protected void Explosion()
    {
        GameObject explosion = Instantiate(MineData.ExplosionPrefab, transform.position, Quaternion.identity);

        OnTriggerEnemy();

        DestroyImmediate(gameObject);

        if (gameObject) { print("chua xoa dc!"); }
    }

    protected void OnTriggerEnemy()
    {
        int i = 0;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, MineData.ExplosionRadius);

        print(MineData.ExplosionPrefab.transform.position);

        foreach (Collider2D collider in colliders)
        {
            GameObject enemy = collider.gameObject;

            Damageable damageable = enemy.GetComponent<Damageable>();
            if (damageable != null)
            {
                print(i + ": " + enemy.name);
                damageable.DealDamage(MineData.ExplosionPower, gameObject);
                i++;
            }

            Knockable enemyKnockback = enemy.GetComponent<Knockable>();
            if (enemyKnockback != null)
            {
                Vector2 knockbackDirection = enemy.transform.position - transform.position;
                knockbackDirection = knockbackDirection.normalized;

                enemyKnockback.KnockBack(knockbackDirection, mineData.Knockback, 0.1f);
            }
        }
    }
}
