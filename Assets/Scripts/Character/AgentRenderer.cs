using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : AgentSystem
{
   private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void FaceDirection(Vector2 pointerPosition)
    {
        Vector2 faceDirection = pointerPosition - (Vector2)transform.position;
        print(1);
        if(faceDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if(faceDirection.x < 0) {
            spriteRenderer.flipX = true;
        }
    }
}
