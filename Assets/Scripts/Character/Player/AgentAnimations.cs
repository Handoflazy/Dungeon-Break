using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentAnimations : PlayerSystem
{

    public static AgentAnimations Instance;
    Rigidbody2D rb;
    public bool isUsingWeapon;
    [SerializeField]
    Animator anim;



    Vector2 lookDirection = Vector2.zero;

    private bool isAlive = true;

    public void OnUsingWeaponEvent(bool isUsingWeapon)
    {
        this.isUsingWeapon = isUsingWeapon;
    }
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();

        Instance = this;
    }

    private void OnEnable()
    {
        player.ID.playerEvents.OnDeath += PlayDeathAnimation;
        player.ID.playerEvents.OnUsingWeapon += OnUsingWeaponEvent;

    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnDeath -= PlayDeathAnimation;
        player.ID.playerEvents.OnUsingWeapon -= OnUsingWeaponEvent;
    }
    private Vector2 GetPointerPos()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    private void Update()
    {
        if (!isAlive)
            return;
        float currentSpeed = rb.velocity.magnitude;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, 1);
        anim.SetFloat(AnimConsts.PLAYER_WALK_SPEED_PARAM, currentSpeed);

        if (isUsingWeapon)
        {
            return;
        }
        lookDirection = GetPointerPos() - (Vector2)transform.position;
        if (lookDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            player.ID.playerEvents.OnLeftSide?.Invoke(false);

        }
        else if (lookDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            player.ID.playerEvents.OnLeftSide?.Invoke(true);
        }

        

    }
    public void PlayDeathAnimation()
    {
        anim.SetTrigger(AnimConsts.PLAYER_DEATH_PARAM);
        isAlive = false;
    }
   


}
