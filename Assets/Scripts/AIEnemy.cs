using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Pathfinding;

public class AIEnemy : AItest
{
    public EnemyState state;
    private RaycastHit2D hit;
    private RaycastHit2D[] hits;
    public float distanceTrigger;
    public Vector2 startPosition;
    public float distanceToDo = 2f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        state = EnemyState.Idle;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.Chasing) {
            hits = Physics2D.BoxCastAll(transform.position, new Vector2(0.16f, 0.16f), 0, target.transform.position - transform.position, distanceTrigger*3f);
            Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.blue);
            bool found = true;
            foreach (var hitTemp in hits)
            {
                if (hitTemp.collider.CompareTag("Player"))
                {
                    found = true;
                    Debug.DrawRay(transform.position, hitTemp.transform.position - transform.position, Color.white);

                    break;
                }
                else
                {
                    found = false;
                }
            }
           if(!found&& Vector2.Distance(transform.position, target.position) >0.5f)
            {
                target = null;
                BackToIdelSate();
                return;
            }
            if (Vector2.Distance(transform.position, target.position) <= distanceToDo)
            {
                dost();
            }
            
        }
    }
    void dost()
    {
        SpriteRenderer temp = hit.collider.GetComponent<SpriteRenderer>();
        temp.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

    }
    void BackToIdelSate()
    {
        state = EnemyState.Idle;
        seeker.StartPath(transform.position, startPosition, OnPathCompelete);


    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == EnemyState.Idle && collision.tag == "Player")
        {
            
            hit = Physics2D.BoxCast(transform.position,new Vector2(0.16f,0.16f),0, collision.transform.position - transform.position, distanceTrigger);

            if (hit&&hit.collider.CompareTag("Player"))
            {
                state = EnemyState.Chasing;
                target = hit.transform;
            }
            
        }
    }
}
