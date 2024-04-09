using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Mover
{
    
    public bool FacingLeft { get { return facingLeft; } }
    private bool facingLeft = false;
    [Header("Reference")]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition, dash;
    private WeaponParent weaponParent;

    private Vector2 oldMovementInput = Vector2.zero;
    private Vector2 pointerInput = Vector2.zero;
    private float currentSpeed = 0;

    [SerializeField]
    private GameObject deathVFXParticlePrefap;

    [Header("Dash")]
    [SerializeField]
    private float dashSpeed = 4f;
    [SerializeField]
    private float dashTime = .2f;
    [SerializeField]
    private float dashCD = 2f;
    private float lastTime = 0;
    [SerializeField]
    private int maxDashTime = 2;
    [SerializeField]
    //private TrailRenderer trailDashRenderer;
   

    
    protected override void Start()
    {
        base.Start();
        dash.action.performed += _ => Dash();
        attack.action.performed += _ => PerformAttack();
        
    }
    private void PerformAttack()
    {
       
        weaponParent.Attack();

    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        weaponParent = GetComponentInChildren<WeaponParent>();
    }
    protected override void ReceivedDamage(Damage dmg)
    {
        base.ReceivedDamage(dmg);
      
    }
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    
    public void Respawn()
    {
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
    Vector2 movementInput;

    private void AnimatedCharacter()
    {
        
        if (rb.velocity.magnitude > 0.05)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {

            anim.SetBool("isMoving", false);

        }

        if (weaponParent.IsAttacking)
        {
            
            movementInput = movement.action.ReadValue<Vector2>()*0.3f;
            
            return;
           
        }
        movementInput = movement.action.ReadValue<Vector2>();
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;

        weaponParent.Pointerposition = pointerInput;

        if (lookDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingLeft = false;
        }
        else if (lookDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingLeft = true;
        }


    }
    void Update()
    {

        pointerInput = GetPointerInput();
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
    
            if (Physics2D.BoxCast(transform.position, boxCollider.size, 0, movementInput,
                Mathf.Abs(moveDelta.magnitude * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor")).collider == null)
            {
                UpdateMotor(movementInput.normalized);
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

       

    }

    public void Healing(int healingAmount)
    {



    }
    public override void Death()
    {
        Instantiate(deathVFXParticlePrefap, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    
    int dashCount = 0;
    void Dash()
    {
        
        if (Time.time - dashCD > lastTime||dashCount<maxDashTime-1)
        {
            if (Time.time - dashCD > lastTime)
            {
                dashCount = 0;
            }
            else
            {
                dashCount++;
            }
            movementInput = (GetPointerInput() - (Vector2)transform.position).normalized;
            //trailDashRenderer.emitting = true;
            UpdateMotor(movementInput);
            lastTime = Time.time;
            currentSpeed = dashSpeed;
            maxSpeed *= dashSpeed;
            StartCoroutine(EndDashRoutine());

            {
                StartCoroutine(ResetDash());
            }
        }
    }
    private IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(dashTime);
        maxSpeed /= dashSpeed;
        UpdateMotor(movementInput);
        //trailDashRenderer.emitting = false;
       
    }
    IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(dashCD); dashCount = 0;
    }


}
