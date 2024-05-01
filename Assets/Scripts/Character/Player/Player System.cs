using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : AgentSystem
{
    protected Player player;
    protected BoxCollider2D boxCollider2D;
    protected virtual void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = transform.root.GetComponent<Player>();
    }
}
