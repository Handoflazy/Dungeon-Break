using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatedCharacter : PlayerSystem
{

    public static AnimatedCharacter Instance;
    Rigidbody2D rb;
    public bool isUsingWeapon;
    [SerializeField]
     Animator anim;

    public void OnUsingWeaponEvent(bool isUsingWeapon)
    {
        this.isUsingWeapon = isUsingWeapon;
    }
    protected override void Awake()
    {
        base.Awake(); rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void OnEnable()
    {
       
     
        player.ID.playerEvents.OnUsingWeapon += OnUsingWeaponEvent;

    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnUsingWeapon -= OnUsingWeaponEvent;
    }
    private Vector2 GetPointerPos()
    {
        Vector3 mousePos;
        mousePos.x = Mouse.current.position.x.ReadValue();
        mousePos.y = Mouse.current.position.y.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void Update()
    {

        if (rb.velocity.magnitude > 0.1)
        {
            anim.SetBool(AnimConsts.PLAYER_RUN_PARAM, true);
        }
        else
        {
            anim.SetBool(AnimConsts.PLAYER_RUN_PARAM, false);
        }
        if (isUsingWeapon)
        {
            return;
        }
        Vector2 lookDirection = GetPointerPos() - (Vector2)transform.position;
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
}
