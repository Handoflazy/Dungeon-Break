using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//using static UnityEngine.RuleTile.TilingRuleOutput;
//using Transform = UnityEngine.Transform;

public class SkillBoss : StateMachineBehaviour
{
    /*    private Transform playerPos;
        public GameObject bulletPrefab;
        public GameObject boomPrefab;
        public GameObject spellPrefab;
        public GameObject skullPrefab;
        public GameObject warningAreaPrefab;
        public GameObject[] enemyPrefab;
        public float spawnRadius = 0.2f;

        public int numberOfBullets = 10;
        Vector2 boomPos = Vector2.zero;*/
    [SerializeField]
    private float timeSinceMultiBullet = 0f;
    [SerializeField]
    private float timeSinceRise = 0f;
    [SerializeField]
    private float timeSinceExplosion = 0f;
    [SerializeField]
    private float timeSinceSkull = 8f;

    public float coldownMulti = 2f;
    public float coldownSpell = 5f;
    public float coldownSummon = 7f;
    public float coldownSkull = 17f;

    //private CoroutineRunner coroutineRunner;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    /*   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
       {
           playerPos = GameObject.FindGameObjectWithTag("Player").transform;

           coroutineRunner = animator.GetComponent<CoroutineRunner>();
           if (coroutineRunner == null)
           {
               coroutineRunner = animator.gameObject.AddComponent<CoroutineRunner>();
           }
       }*/

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeSinceMultiBullet += Time.deltaTime;
        timeSinceRise += Time.deltaTime;
        timeSinceExplosion += Time.deltaTime;
        timeSinceSkull += Time.deltaTime;

        if (timeSinceMultiBullet >= coldownMulti)
        {
            //MultiBullet(animator);
            animator.SetTrigger("MultiSkull");
            timeSinceMultiBullet = 0f;
        }
        if (timeSinceExplosion >= coldownSpell)
        {
            //ExplosionSkill(animator);
            animator.SetTrigger("Spell");
            timeSinceExplosion = 0f;
        }
        if (timeSinceRise >= coldownSummon)
        {
            //Summoning(animator);
            animator.SetTrigger("Summon");
            timeSinceRise = 0f;
        }
        if (timeSinceSkull >= coldownSkull)
        {
            //SkullFollow(animator);
            animator.SetTrigger("SkullFollow");
            timeSinceSkull = 0f;
        }
    }
    
/*    private void MultiBullet(Animator animator)
    {
        float maxScatterAngle = (numberOfBullets - 1) * 10;
        float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;
        float initialScatterAngle = -maxScatterAngle;
        float bulletSpacing = 0f;
        for (int j = 0; j < numberOfBullets; j++)
        {
            GameObject bullet = Instantiate(bulletPrefab, animator.transform.position, Quaternion.identity);
            Vector3 lookDirection = (playerPos.position - animator.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.right*0.7f;
            initialScatterAngle += angleBetweenBullets;
            bullet.transform.position += bullet.transform.right * (bulletSpacing);
            timeSinceMultiBullet = 0f;
            Destroy(bullet, 3f);
        }
    }

    private void Summoning(Animator animator)
    {
        //GameObject enemy = Instantiate(enemyPrefab, animator.transform.position, Quaternion.identity);
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = animator.transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f);
            Instantiate(enemyPrefab[enemyIndex], spawnPosition, Quaternion.identity);
        }
        timeSinceRise = 0f;
    }

    private void ExplosionSkill(Animator animator)
    {
        GameObject warningArea = Instantiate(warningAreaPrefab, playerPos.transform.position, Quaternion.identity);
        GameObject spell = Instantiate(spellPrefab, playerPos.transform.position, Quaternion.identity);
        boomPos = new Vector2(playerPos.position.x, playerPos.position.y);
        coroutineRunner.StartCoroutine(AreaSkill(animator));
        timeSinceExplosion = 0f;
        Destroy(warningArea, 1f);
        Destroy(spell, 1.2f);
    }
    
    private void SkullFollow(Animator animator)
    {
        GameObject skull = Instantiate(skullPrefab, animator.transform.position, Quaternion.identity);
        timeSinceSkull = 0f;
    }
    IEnumerator AreaSkill(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        
        GameObject boom = Instantiate(boomPrefab, boomPos, Quaternion.identity);
        Destroy(boom, 1f);
    }*/
}
