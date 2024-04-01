using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Arrow : Collidable
{

    protected override void OnCollide(Collider2D other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("Actor") && other.CompareTag("Fighter"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Blocking"))
        {
            Destroy(gameObject);
        }
    }
}