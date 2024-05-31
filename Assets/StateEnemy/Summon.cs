using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Summon : StateMachineBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnRadius = 0.5f;
    public int numberSpawnEnemy = 2;
    public AudioSource audioSource;
    public AudioClip clipSound;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = animator.GetComponent<AudioSource>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Summoning(animator);
    }

    private void Summoning(Animator animator)
    {
        //GameObject enemy = Instantiate(enemyPrefab, animator.transform.position, Quaternion.identity);
        for (int i = 0; i < numberSpawnEnemy; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = animator.transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f);
            Instantiate(enemyPrefab[enemyIndex], spawnPosition, Quaternion.identity);
            audioSource.PlayOneShot(clipSound);
        }
    }


}
