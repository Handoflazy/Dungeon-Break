using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : EnemySystem
{
    private Rigidbody2D rb;
    [field: SerializeField]
    MovementDataS0 MovementData { get; set; }


    protected float currentSpeed = 0;
    private Vector2 oldMovementInput = Vector2.zero;
    private Vector2 newMovementInput = Vector2.zero;
    private float speedLimitActor = 1f;


    //Combat
    Vector2 pushDirectIon;
    [Range(0, 1), SerializeField] float pushResist;

    private void OnEnable()
    {
        player.playerEvents.OnMove += MoveAgent;
    }
    private void OnDisable()
    {
        player.playerEvents.OnMove -= MoveAgent;
    }

    public void MoveAgent(Vector2 movementInput)
    {
 
        newMovementInput = movementInput.normalized;

    }
    private void FixedUpdate()
    {
       
            UpdateMotor(newMovementInput * speedLimitActor + pushDirectIon);
       

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
            currentSpeed += MovementData.acceleration * MovementData.maxSpeed * Time.deltaTime;

        }
        else
        {
            currentSpeed -= MovementData.deceleration * MovementData.maxSpeed * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, MovementData.maxSpeed);

        rb.velocity = oldMovementInput * currentSpeed;

    }
}
