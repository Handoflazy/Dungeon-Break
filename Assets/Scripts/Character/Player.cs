using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player2 : Mover
{
    [Header("Reference")]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;
    private WeaponParent weaponParent;

    private Vector2 oldMovementInput = Vector2.zero;
    private Vector2 pointerInput = Vector2.zero;
    private float currentSpeed = 0;
    private bool isAlive;

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }
    private void OnDisable()
    {
        attack.action.canceled -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {

        weaponParent.Attack();

    }


    private void Awake()
    {
        isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

        weaponParent = GetComponentInChildren<WeaponParent>();
        


    }
    protected override void ReceivedDamage(Damage dmg)
    {
        if (!isAlive) { return; }
        base.ReceivedDamage(dmg);
       
    }
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public void SetRender(int id)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[id];
    }
    public void Respawn()
    {
        health.InitialHealth(maxHealth);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
    Vector2 movementInput;

    private void AnimatedCharacter()
    {
       
        if (movementInput.magnitude > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            if (movementInput.magnitude == 0)
            {
                anim.SetBool("isMoving", false);
            }
        }
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        if (weaponParent.IsAttacking)
            return;
   
        if (lookDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (lookDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }


    }
    void Update()
    {


        movementInput = movement.action.ReadValue<Vector2>();
        if (weaponParent.IsAttacking)
        {
            return;
        }
        pointerInput = GetPointerInput();
        weaponParent.Pointerposition = pointerInput;
        AnimatedCharacter();

    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            if (Physics2D.BoxCast(transform.position, boxCollider.size, 0, movementInput,
                Mathf.Abs(moveDelta.magnitude * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor")).collider == null)
            {
                UpdateMotor(movementInput.normalized);
            }

        }
    }
    protected override void UpdateMotor(Vector2 Input)
    {
        if (Input.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = movementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb.velocity = oldMovementInput * currentSpeed;

    }
    public void OnLevelUp()
    {
        
        GameManager.instance.ShowText("Level Up!", 30, Color.green, transform.position, Vector3.up, 2.0f);

    }

    public void Healing(int healingAmount)
    {

        if (!health.IsFull)
        {
            health.Heal(healingAmount);
        }


    }
    protected override void Death()
    {
        isAlive = false;
        base.Death();
        //GameManager.instance.deathAim.SetBool("isDeath", true);
    }

}
