using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
   
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    [Header("Move Setting")]
    [SerializeField] protected float acceleration = 0.2f;

    [SerializeField] protected float deceleration = 0.2f;
    
    [SerializeField] protected float maxSpeed = 1f;
    
    protected RaycastHit2D hit;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector2 Input)
    {
        moveDelta = Input;
        if (Input.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (Input.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection,Vector3.zero, pushRecoverySpeed);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, moveDelta, Mathf.Abs(moveDelta.magnitude * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if (hit.collider == null)
        {
            rb.velocity = moveDelta * acceleration;
        }
        rb.velocity = moveDelta * acceleration;
    }
}
