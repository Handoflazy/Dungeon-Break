using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Interatable : MonoBehaviour
{
    [SerializeField]
    private InputActionReference interactKey;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")){
            print(1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("out");
    }
}
