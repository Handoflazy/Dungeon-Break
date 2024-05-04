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
    private void OnEnable()
    {
        player.ID.playerEvents.OnMove += MoveAgent;
        player.ID.playerEvents.OnUsingWeapon += OnAttackingEvent;
        player.ID.playerEvents.OnMoveSkillUsing += OnMoveSkillUsingEvent;
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }
    protected void OnDisable()
    {
        player.ID.playerEvents.OnMove -= MoveAgent;
        player.ID.playerEvents.OnUsingWeapon -= OnAttackingEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= OnMoveSkillUsingEvent;
    }
}
