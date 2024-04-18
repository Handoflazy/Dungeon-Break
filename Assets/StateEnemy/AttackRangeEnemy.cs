using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class AttackRangeEnemy : StateMachineBehaviour
{
    protected DetectPlayer detectTarget;
    public Transform player;
    //public GameObject bulletPrefab;
    public int numberOfBullets = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        detectTarget = animator.GetComponent<DetectPlayer>();
        player = detectTarget.DetectTarget();
        if (player != null)
        {
            if (player.position.x > animator.transform.position.x)
            {
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (player.position.x < animator.transform.position.x)
            {
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            float maxScatterAngle = (numberOfBullets - 1) * 10;
            // Tính góc giữa các viên đạn
            float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;
            float initialScatterAngle = -maxScatterAngle;
            float bulletSpacing = 0f;
            for (int i = 0; i < numberOfBullets; i++)
            {

                GameObject bullet = ObjectPoolEnemy.SharedInstance.GetPooledBulletEnemy();
                if (bullet != null)
                {
                    bullet.transform.position = animator.transform.position;
                    bullet.transform.rotation = animator.transform.rotation;
                    bullet.SetActive(true);
                }

                Vector3 lookDirection = (player.position - animator.transform.position).normalized;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = bullet.transform.right;
                initialScatterAngle += angleBetweenBullets;
                bullet.transform.position += bullet.transform.right * (bulletSpacing);
                //Destroy(bullet, 3f);

            }

        }



       
    }

}
