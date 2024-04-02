using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : Mover
{
    public float knockbackForce = 5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fighter"))
        {
            // Áp dụng knockback cho enemy
            Rigidbody2D enemyRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // Lấy hướng knockback
                Vector2 knockbackDirection = other.transform.position - transform.position;
                knockbackDirection = knockbackDirection.normalized;

                // Áp dụng knockback bằng cách áp lực lên Rigidbody của enemy
                enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
