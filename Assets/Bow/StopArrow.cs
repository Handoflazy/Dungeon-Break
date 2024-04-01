using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class StopArrow : Collidable
{
    public float knockbackForce = 2f;
    public GameObject Explosion;



 
    protected override void OnCollide(Collider2D other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("Actor") && other.CompareTag("Fighter"))
        {

             /*// Lấy tham chiếu đến thành phần Rigidbody2D của đối tượng Enemy
             Rigidbody2D enemyRigidbody = other.GetComponent<Rigidbody2D>();

             // Kiểm tra xem enemyRigidbody có tồn tại không
             if (enemyRigidbody != null)
             {
                  // Tính toán hướng từ Enemy đến mũi tên Player
                  Vector2 direction = (transform.position - other.transform.position).normalized;

                  // Áp dụng lực đẩy cho Enemy
                  enemyRigidbody.AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
             }*/
       
            Destroy(gameObject);
            //knockBack = false;    
            GameObject bullet_explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            bullet_explosion.SetActive(true); // "Explode" là tên Trigger trong Animator Controller
            Destroy(bullet_explosion, 1f);
        }


        else if (other.gameObject.layer == LayerMask.NameToLayer("Blocking"))
        {
            GameObject bullet_explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            bullet_explosion.SetActive(true); // "Explode" là tên Trigger trong Animator Controller
            Destroy(bullet_explosion, 1f);
            Destroy(gameObject);
        }
    }











    /*    void KnockBack(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Actor") && other.CompareTag("Fighter"))
            {
                // Lấy tham chiếu đến thành phần Rigidbody2D của đối tượng Enemy
                Rigidbody2D enemyRigidbody = other.GetComponent<Rigidbody2D>();

                // Kiểm tra xem enemyRigidbody có tồn tại không
                if (enemyRigidbody != null)
                {
                    // Tính toán hướng từ Enemy đến mũi tên Player
                    Vector2 direction = (transform.position - other.transform.position).normalized;

                    // Áp dụng lực đẩy cho Enemy
                    enemyRigidbody.AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }*/
    /*    private Rigidbody2D rb;
        // Start is called before the first frame update

        // Update is called once per frame

        private void Start()
        {

            rb = GetComponent<Rigidbody2D>();

        }*/

    /*public void CollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            return;
        }
        if (coll.gameObject.CompareTag("Fighter"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.layer == LayerMask.NameToLayer("Blocking"))
        {
            rb.simulated = false;
            StartCoroutine(Wait(2.0f));
            
            *//*rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;*//*
        }
        

    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        rb.simulated = true;
        
    }*/
    /*    private void Start()
        {
            StartCoroutine(Wait(9.5f));
        }

        //Disnable arrow
        IEnumerator Wait(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.SetActive(false);

        }*/
}