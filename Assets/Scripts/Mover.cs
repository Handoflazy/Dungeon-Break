using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    [SerializeField] protected float speed = 0.2f;
    protected RaycastHit2D hit;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
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
            transform.Translate(speed * Time.deltaTime * moveDelta);
        }
    }
}
