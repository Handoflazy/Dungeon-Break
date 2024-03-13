using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;
    protected override void OnCollide(Collider2D other)
    {
        if(other.name == "Player")
        {
            OnCollect();
        }
    }
    protected virtual void OnCollect() {
            collected = true;
    }
}
