using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : Collidable
{
    private AgentInput agentInput;
    public UnityEvent OnPlayerNear;
    public UnityEvent<GameObject> OnInteract;
    private void Awake()
    {
        agentInput = FindObjectOfType<AgentInput>();
        
    }
    protected override void OnCollide(Collider2D other)
    {

        if (agentInput.Interact)
        {
            OnInteract?.Invoke(other.gameObject);
            agentInput.Interact = false;
        }
        OnPlayerNear?.Invoke();
    }

  
}
