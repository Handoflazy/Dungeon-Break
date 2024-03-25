using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : SteeringBehavior
{
    [SerializeField]
    private float radius = 0.32f, agentColliderSize = 0.6f;
    [SerializeField]
    private bool showGizmo = true;

    [SerializeField]
    float[] dangerResultTemp = null;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aIData)
    {
        foreach (Collider2D obstacleCollider in aIData.obstacles)
        {
            Vector2 directionToObstacle = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;
            float distanceToObstacle = directionToObstacle.magnitude;

            float weight = distanceToObstacle <= agentColliderSize ? 1 : (radius - distanceToObstacle) / radius;
            Vector2 directionToObstacleNomalized = directionToObstacle.normalized;
            for (int i = 0; i < Directions.eightDirections.Count; i++)
            {
                float result = Vector2.Dot(directionToObstacleNomalized, Directions.eightDirections[i]);
                float valueToPutIn = result*weight;
                if (valueToPutIn > danger[i])
                {
                    danger[i] = valueToPutIn;
                }
            }
           
        }
        dangerResultTemp = danger;
        return (danger,interest);
        
    }
    private void OnDrawGizmos()
    {
        if(showGizmo == false)return;
        if (Application.isPlaying && dangerResultTemp != null)
        {
            Gizmos.color = Color.red;
            for(int i =0;i<dangerResultTemp.Length;i++)
            {
                Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * dangerResultTemp[i]);
            }
        }
    }
}

public static class Directions
{
    public static List<Vector2> eightDirections = new List<Vector2>
    {
        new Vector2(0,1).normalized,
        new Vector2(0.5f,1).normalized,
        new Vector2(1,1).normalized,
        new Vector2(1,0.5f).normalized,

        new Vector2(1,0).normalized,
        new Vector2(1,-0.5f).normalized,
        new Vector2(1,-1).normalized,
        new Vector2(0.5f,-1).normalized,

        new Vector2(0,-1).normalized,
        new Vector2(-0.5f,-1).normalized,
        new Vector2(-1,-1).normalized,
        new Vector2(-1,-0.5f).normalized,

        new Vector2(-1, 0).normalized,
        new Vector2(-1,0.5f).normalized,
        new Vector2(-1,1).normalized,
        new Vector2(-0.5f,1).normalized




    };
}
