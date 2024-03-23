using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextResolver : MonoBehaviour
{
    [SerializeField]
    private bool showGizmoz = true;

    float[] interestGizmo = new float[0];
    Vector2 resultDirection = Vector2.zero;
    private float rayLength = 0.16f;

    private void Start()
    {
        interestGizmo = new float[8];
    }

    public Vector2 GetDirectionToMove(List<SteeringBehavior> behaviours,AIData aIData)
    {
        float[] danger = new float[8];
        float[] interest = new float[8];
        foreach(SteeringBehavior behavior in behaviours)
        {
            (danger,interest) = behavior.GetSteering(danger,interest,aIData);
        }
        for(int i = 0; i < 8; i++)
        {
            interest[i] = Mathf.Clamp01(interest[i] - danger[i]);

        }
        interestGizmo = interest;

        Vector2 outputDirection = Vector2.zero;
        for(int i = 0;i<8;i++)
        {
            outputDirection += Directions.eightDirections[i] * interest[i];
        }
        outputDirection.Normalize();
        resultDirection = outputDirection;
        return resultDirection;
    }
    private void OnDrawGizmos()
    {
        if (Application.isPlaying && showGizmoz)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, resultDirection * rayLength);
        }
    }
}
