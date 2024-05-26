using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackAction : AIAction
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 10;
    public bool scattering = false;
    public bool radiation = false;
    //public Animator animator;
    public override void TakeAction()
    {
        //print(Vector2.Distance(transform.parent.position, enemyAIBrain.Target.transform.position));
        aiMovementData.Direction = Vector3.zero;
        aiMovementData.PointOfInterest = enemyAIBrain.Target.transform.position;
        enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        aiActionData.Attack = true;
        
        if (scattering==true)
        {
            enemyAIBrain.RangeAttack(bulletPrefab, numberOfBullets);
            //animator.SetTrigger("Attack");
        }
        else if(radiation==true)
        {
            //animator.SetTrigger("Attack");
            enemyAIBrain.RangeAttackV2(bulletPrefab, numberOfBullets);
            //animator.SetTrigger("Attack");
        }
    }
}
