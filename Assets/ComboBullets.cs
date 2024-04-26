using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class ComboBullets : StateMachineBehaviour
{
    
    public Transform player;
    public GameObject bulletPrefab;
    public float bulletSpacing = 0.2f;
    //public float timesinceFire = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*detectTarget = animator.GetComponent<DetectPlayer>();
        player = detectTarget.DetectTarget();*/
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
        //timesinceFire = Time.deltaTime;
        MultiBullet(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MultiBullet(animator);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    private void MultiBullet(Animator animator)
    {

        /*for (int i = 1; i < 5; i++)
        {*/
        /*GameObject bullet = ObjectPool.SharedInstance.GetPooledBulletEnemy();
        if (bullet != null)
        {
            bullet.transform.position = animator.transform.position;
            bullet.transform.rotation = animator.transform.rotation;
            bullet.SetActive(true);
        }*/
            GameObject bullet = Instantiate(bulletPrefab, animator.transform.position, animator.transform.rotation);
            Vector3 lookDirection = (player.position - animator.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.right * 0.7f;

            bullet.transform.position += bullet.transform.right*bulletSpacing ;
        //}
        /*else if (timesinceFire>= 1f)
        {
            
            //animator.SetBool("ComboBullet", false);
        }*/
    }


}
