using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Reward;
    public int xpValue = 1;
    // Logic
    public float triggerLenth = 0.3f;
    public float chaseLength = 1.0f; // RANGE MOB
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPostion;

    //hitBox
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];
    public ContactFilter2D contactFilter;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPostion = transform.position;
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();

    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPostion) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) < triggerLenth)
            {
                chasing = true;
            }
                if (chasing)
                {
                    if(!collidingWithPlayer)
                    {
                        UpdateMotor((playerTransform.position - transform.position).normalized);
                    }
                }
                else
                {
                    UpdateMotor(startingPostion - transform.position);
                }
            
        }
        else
        {
            UpdateMotor(startingPostion - transform.position);
            chasing = false;
        }
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(contactFilter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) {
                continue;
            }
            if (hits[i].CompareTag("Fighter")&& hits[i].name == "Player"){
                collidingWithPlayer = true;
            }
            hits[i] =null;
        
        }
        UpdateMotor(Vector3.zero);
    }
    protected override void Death()
    {
        gameObject.SetActive(false);
        GameManager.instance.GrandXp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.blue, transform.position, Vector3.up * 40, 1.0f);
        if(GameManager.instance.GetExperience() > GameManager.instance.GetTotalExpToNextLvl()) {
            GameManager.instance.LevelUp();
        
        }
    }
}
