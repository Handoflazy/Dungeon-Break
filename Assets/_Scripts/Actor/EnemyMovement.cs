using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : AgentMovement
{
    protected EnemyAIBrain player; 
    private void OnEnable()
    {
        player.playerEvents.OnMove += MoveAgent;
    }
    private void OnDisable()
    {
        player.playerEvents.OnMove -= MoveAgent;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Awake()
    {

        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        player = transform.root.GetComponent<EnemyAIBrain>();
    }

   
}
