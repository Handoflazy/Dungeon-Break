using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : PlayerSystem
{
    private Rigidbody2D rb;
    [SerializeField] protected float acceleration = 0.2f;

    [SerializeField] protected float deceleration = 0.2f;

    [SerializeField] protected float maxSpeed = 1f;
    private float currentSpeed = 0;
    private Vector2 oldMovementInput = Vector2.zero;
    private Vector2 newMovementInput = Vector2.zero;
    private float speedLimitActor = 1f;


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
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }
    private void OnBePush(Vector2 pushDirection)
    {
        this.pushDirectIon = pushDirection;
    }
    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        currentSpeed = 0;
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
            speedLimitActor = 0.3f;
        }
        else
        {
            speedLimitActor = 1;
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
            UpdateMotor(newMovementInput*speedLimitActor+pushDirectIon);
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
