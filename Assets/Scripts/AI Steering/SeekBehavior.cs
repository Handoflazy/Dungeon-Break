using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeekBehavior : SteeringBehavior
{

    [SerializeField]
    private float targetRechedThreshold = 0.5f;

    [SerializeField]
    private bool showGizmo = true;

    bool reachedLastTarget = true;

    //Gizmo parameters
    private Vector2 targetPositionCatched;
    private float[] interestedTemp;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aIData)
    {
        if(reachedLastTarget)
        {
            if(aIData.targets==null|| aIData.targets.Count <=0)
            {
                aIData.currentTarget = null;
                return (danger,interest);
            }
            else
            {
                reachedLastTarget=false;
                aIData.currentTarget = aIData.targets.OrderBy(target=>Vector2.Distance(target.position,transform.position)).FirstOrDefault();   

            }
        }
        if (aIData.currentTarget != null && aIData.targets != null && aIData.targets.Contains(aIData.currentTarget)){
            targetPositionCatched = aIData.currentTarget.position;
        }
        if(Vector2.Distance(transform.position,targetPositionCatched) < targetRechedThreshold) {
            reachedLastTarget = true;
            aIData.currentTarget = null;
            return (danger,interest);
            
        }
        Vector2 directionToTarget = (targetPositionCatched - (Vector2)transform.position);
        for(int i = 0;i<interest.Length;i++)
        {
            Vector2 leftVector = new Vector2(-directionToTarget.y, directionToTarget.x);
            Vector2 rightVector = -leftVector;
            //float dotLeft = Vector2.Dot(leftVector.normalized, Directions.eightDirections[i]);
            //float dotRight = Vector2.Dot(rightVector.normalized, Directions.eightDirections[i]);
            //float result = dotLeft > dotRight ? dotLeft : dotRight;
            float result = Vector2.Dot(Directions.eightDirections[i], directionToTarget.normalized);
            if (result > 0)
            {
                float valueToPutIn = result;
                if(valueToPutIn> interest[i])
                {
                    interest[i] = valueToPutIn;
                }
            }
        }
        interestedTemp = interest;
        return (danger,interest);
    }
    
    
   
    private void OnDrawGizmos()
    {
        if (!showGizmo)
        {
            return;
        }
        Gizmos.DrawSphere(targetPositionCatched, 0.05f);
        if(Application.isPlaying && interestedTemp != null)
        {
            Gizmos.color = Color.green;
            for(int i = 0;i<interestedTemp.Length;i++)
            {
                Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * interestedTemp[i]*0.32f);
            }
            if (!reachedLastTarget)
            {
                Gizmos.color= Color.red;
                Gizmos.DrawSphere(targetPositionCatched, 0.05f);
            }
        }
    }
}
