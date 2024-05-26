using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldLookDecision : AIDecision
{
    [SerializeField]
    private float viewRadius;

    [SerializeField,Range(0,360)]
    private float viewAngle;

    [SerializeField] private LayerMask targetMask;
    public Vector3 DirFromAngle(float angleDegree)
    {
        if (!aiActionData)
            return Vector3.zero;
        Vector2 interestDir = (aiMovementData.PointOfInterest - (Vector2)transform.position).normalized;
        float finalAngle = Vector2.Angle(interestDir, transform.right) + angleDegree;
        print(finalAngle);
        Debug.DrawRay(transform.position, interestDir, Color.red, .1f);
        return new Vector3(Mathf.Cos(finalAngle * Mathf.Deg2Rad), Mathf.Sin(finalAngle * Mathf.Deg2Rad), 0);
    }




    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, viewRadius);
            Gizmos.color = Color.white;



            Vector3 viewAngleA = DirFromAngle(-viewAngle/2);
            Vector3 viewAngleB = DirFromAngle(viewAngle/2);

            Gizmos.DrawLine(transform.position,transform.position+ viewAngleB*viewRadius);
            Gizmos.DrawLine(transform.position,transform.position+ viewAngleA*viewRadius);
            
        }
    }

    public override bool MakeDecision()
    {
        Vector2 dirToTarget = (enemyAIBrain.Target.transform.position - transform.position).normalized;
        if (Vector2.Angle(transform.right, dirToTarget) < viewAngle / 2)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, viewRadius, targetMask);
            if (hit)
            {
                if(hit.collider && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")){
                    return true;
                }
            }
        }
        return false;
    }
}
