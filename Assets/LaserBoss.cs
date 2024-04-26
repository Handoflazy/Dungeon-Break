using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBoss : StateMachineBehaviour
{
    public Transform playerPos;
    public GameObject laserPrefab;
    //public GameObject spellPrefab;
    //public GameObject warningAreaPrefab;
    Vector2 boomPos = Vector2.zero;
    private CoroutineRunner coroutineRunner;
    public int numberOfBullets;
    public float bulletSpacing = 0.2f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //collision.gameObject.layer == LayerMask.NameToLayer("Blocking")

        /*coroutineRunner = animator.GetComponent<CoroutineRunner>();
        if (coroutineRunner == null)
        {
            coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
        }*/


    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LaserSkill(animator);
    }

    private void LaserSkill(Animator animator)
    {

        float maxScatterAngle = (numberOfBullets - 1) * 20;
        float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;
        float initialScatterAngle = -maxScatterAngle;
        
        for (int j = 0; j < numberOfBullets; j++)
        {
            //GameObject bullet = Instantiate(bulletPrefab, animator.transform.position, Quaternion.identity);

            /*GameObject bullet = ObjectPool.SharedInstance.GetPooledBulletBoss();
            if (bullet != null)
            {
                bullet.transform.position = animator.transform.position;
                bullet.transform.rotation = animator.transform.rotation;
                bullet.SetActive(true);
            }*/

            Vector3 lookDirection = (playerPos.position - animator.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;

            GameObject laser = Instantiate(laserPrefab, animator.transform.position, Quaternion.identity);
            laser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            initialScatterAngle += angleBetweenBullets;
            laser.transform.position += laser.transform.right * (bulletSpacing);
            Destroy(laser, 1.5f);
            //Destroy(bullet, 5f);
            //bullet.SetActive(false);
        }


    }


    /*IEnumerator AreaSkill(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        //GameObject boom = Instantiate(laserPrefab, animator.transform.position, Quaternion.identity);
        //Destroy(boom, 1f);
    }*/
}
