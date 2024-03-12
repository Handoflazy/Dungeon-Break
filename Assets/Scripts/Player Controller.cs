using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    [SerializeField] float speed = 0.2f;
    private RaycastHit2D hit;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Ray2D ray = new Ray2D(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(horizontalInput, verticalInput, 0).normalized;
        if(horizontalInput >0)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, moveDelta,Mathf.Abs(moveDelta.magnitude*Time.deltaTime),LayerMask.GetMask("Blocking","Actor"));
       
        if(hit.collider == null) {
            transform.Translate(moveDelta * speed);
        }
    }
  
}
