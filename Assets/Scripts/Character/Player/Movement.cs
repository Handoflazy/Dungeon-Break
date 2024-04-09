using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : PlayerSystem
{
    private Rigidbody2D rb;
    [SerializeField] protected float acceleration = 0.2f;

    [SerializeField] protected float deceleration = 0.2f;

    [SerializeField] protected float maxSpeed = 1f;
    private float currentSpeed = 0;
    private Vector2 oldMovementInput = Vector2.zero;
    private Vector2 newMovementInput = Vector2.zero;
    private float speedLimitAction = 0.3f;


    //Combat
    Vector2 pushDirectIon;
    [Range(0,1),SerializeField] float pushResist;



    bool isMoveSkillUsing;
    private void OnEnable()
    {
        player.ID.playerEvents.OnMove += ResponseTrigger;
        player.ID.playerEvents.OnUsingWeapon += OnAttackingEvent;
        player.ID.playerEvents.OnMoveSkillUsing += OnMoveSkillUsingEvent;
        player.ID.playerEvents.OnBeginPush += OnBePush;
    }
    private void OnBePush(Vector2 pushDirection)
    {
        this.pushDirectIon = pushDirection;
    }
    

    private void OnDisable()
    {
        player.ID.playerEvents.OnMove -= ResponseTrigger;
        player.ID.playerEvents.OnUsingWeapon -= OnAttackingEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= OnMoveSkillUsingEvent;
        player.ID.playerEvents.OnBeginPush -= OnBePush;
    }
    void OnMoveSkillUsingEvent(bool isUsed)
    {
        isMoveSkillUsing = isUsed;
       
    }

    void OnAttackingEvent(bool mode)
    {
        if(mode)
        {
            speedLimitAction = 0.3f;
        }
        else
        {
            speedLimitAction = 1;
        }
    }
    void ResponseTrigger(Vector2 movementInput)
    {
        newMovementInput = movementInput;
    }
    private void FixedUpdate()
    {
        pushDirectIon = Vector3.Lerp(pushDirectIon, Vector3.zero, pushResist);
        if (!isMoveSkillUsing) { 
            UpdateMotor(newMovementInput*speedLimitAction+pushDirectIon);
        }
        
    }
    protected override void Awake()
    {

        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    void UpdateMotor(Vector2 Input)
    {
        
        if (Input.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = Input;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;

        }
        else
        {
            currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        rb.velocity = oldMovementInput * currentSpeed;

    }
}
