using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//using static UnityEngine.RuleTile.TilingRuleOutput;
//using Transform = UnityEngine.Transform;

public class MultiSkull : StateMachineBehaviour
{
    private Transform playerPos;
    public GameObject bulletPrefab;
    public int numberOfBullets = 10;
    public AudioSource audioSource;
    public AudioClip clipSound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = animator.GetComponent<AudioSource>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MultiBullet(animator);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    private void MultiBullet(Animator animator)
    {
        float maxScatterAngle = (numberOfBullets - 1) * 10;
        float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;
        float initialScatterAngle = -maxScatterAngle;
        float bulletSpacing = 0f;
        for (int j = 0; j < numberOfBullets; j++)
        {
            GameObject bullet = Instantiate(bulletPrefab, animator.transform.position, Quaternion.identity);

            /*GameObject bullet = ObjectPoolEnemy.SharedInstance.GetPooledBulletBoss();
            if (bullet != null)
            {
                bullet.transform.position = animator.transform.position;
                bullet.transform.rotation = animator.transform.rotation;
                bullet.SetActive(true);
            }*/

            Vector3 lookDirection = (playerPos.position - animator.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.right * 0.7f;
            initialScatterAngle += angleBetweenBullets;
            bullet.transform.position += bullet.transform.right * (bulletSpacing);
            Destroy(bullet, 5f);
            //bullet.SetActive(false);
            audioSource.PlayOneShot(clipSound);
        }
    }

 
}
