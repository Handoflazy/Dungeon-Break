using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AgentMovement))]
public class Knockable : MonoBehaviour
{
    private AgentMovement agentMovement;
    private void Awake()
    {
        agentMovement = GetComponent<AgentMovement>();
    }
    public void KnockBack(Vector2 direction, float power, float duration)
    {
        agentMovement.Knockback(direction, power, duration);
    }
}
