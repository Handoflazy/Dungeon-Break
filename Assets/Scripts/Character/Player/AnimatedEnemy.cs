using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedEnemy : PlayerSystem
{
    Rigidbody2D rb;
    protected override void Awake()
    {
        base.Awake();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        if (rb.velocity.magnitude > 0.1)
        {
            anim.SetBool("OnRun", true);
        }
        else
        {
            anim.SetBool("OnRun", false);
        }
        if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
           
        }
        else if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
          

        }

    }
}
