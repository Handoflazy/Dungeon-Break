using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    protected PlayerReform player;
    protected BoxCollider2D boxCollider2D;
    protected Animator anim;
    protected virtual void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = transform.root.GetComponent<PlayerReform>();
        anim = GetComponentInChildren<Animator>();
    }
}
