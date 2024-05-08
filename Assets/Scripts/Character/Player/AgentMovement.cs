using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public abstract class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider2D;
    [field:SerializeField]
    MovementDataS0 MovementData { get; set; }


    protected float currentSpeed = 0;
    protected Vector2 oldMovementInput = Vector2.zero;
    protected Vector2 newMovementInput = Vector2.zero;
    protected float speedLimitActor = 1f;


    bool isMoveSkillUsing;
    protected bool isKnockback;
    protected virtual void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        currentSpeed = 0;
    }

    protected virtual void OnMoveSkillUsingEvent(bool isUsed)
    {
        isMoveSkillUsing = isUsed;
       
    }

    protected virtual void OnAttackingEvent(bool mode)
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
    public virtual void MoveAgent(Vector2 movementInput)
    {
        //if(Vector2.Dot(oldMovementInput,movementInput) <0) {
        //    currentSpeed = 0;
        //}
        newMovementInput = movementInput.normalized;

    }
    protected virtual void FixedUpdate()
    {

        if (!isMoveSkillUsing&&!isKnockback) { 
            UpdateMotor(newMovementInput*speedLimitActor);
        }
        
    }
    protected  virtual void Awake()
    {

       boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void UpdateMotor(Vector2 Input)
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
    public virtual void Knockback(Vector2 direction,float power,float duration)
    {
        if (isKnockback==false)
        {
            isKnockback = true;
            StartCoroutine(KnockBackCoroundtine(direction, power, duration));

        }
    }
    public virtual void ResetKnockback()
    {
        
        StopCoroutine("KnockBackCoroundtine");
        ResetKnockBackParameters();
    }

    protected IEnumerator KnockBackCoroundtine(Vector2 direction, float power, float duration)
    {
        rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockBackParameters();
    }

    protected virtual void ResetKnockBackParameters()
    {
        currentSpeed = 0;
        rb.velocity = Vector2.zero;
        isKnockback = false;
    }



}
