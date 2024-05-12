using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : AgentMovement
{
    protected Player player;
    protected override void Awake()
    {
        base.Awake();
        player = transform.root.GetComponent<Player>();
    }
    protected  void OnEnable()
    {
        player.ID.playerEvents.OnMove += MoveAgent;
        player.ID.playerEvents.OnMoveSkillUsing += OnMoveSkillUsingEvent;
        SceneManager.activeSceneChanged += OnActiveSceneChanged; 
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        player.ID.playerEvents.OnMove -= MoveAgent;
        player.ID.playerEvents.OnMoveSkillUsing -= OnMoveSkillUsingEvent;
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }
}
