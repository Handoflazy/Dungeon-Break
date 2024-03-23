using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using UnityEngine.Android;

public class AIEnemyMover : MonoBehaviour
{
    [Header("AIMover")]
    public Vector3 targetPosition;

    private Seeker seeker;

  
    public float targetRechedThreshold = 0.5f;

    public Path path;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    //public float repathRate = 0.5f;

    public bool reachedEndOfPath;

    [SerializeField]
    private bool showGizmo = true;

    protected void Start()
    {

        seeker = GetComponent<Seeker>();
        // If you are writing a 2D game you can remove this line
        // and use the alternative way to move sugggested further below.


    }

    public void OnPathComplete(Path p)
    {

        p.Claim(this);
        if (!p.error)
        {
            path?.Release(this);
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
            reachedEndOfPath = false;
        }
        else
        {
            p.Release(this);
        }
    }
    public void UpdatePath()
    {
        if (targetPosition != null && seeker.IsDone())
        {

            seeker.StartPath(transform.position, targetPosition, OnPathComplete);
        }
    }
    protected void UpdatePathToHome(Vector2 homePosition)
    {
        seeker.StartPath(transform.position, homePosition, OnPathComplete);
    }

    //protected virtual void LateUpdate()
    //{
    //    //if (Time.time > lastRepath + repathRate && seeker.IsDone())
    //    //{
    //    //    lastRepath = Time.time;

    //    //    // Start a new path to the targetPosition, call the the OnPathComplete function
    //    //    // when the path has been calculated (which may take a few frames depending on the complexity)
    //    //    seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    //    //}

    //    if (path == null)
    //    {
    //        // We have no path to follow yet, so don't do anything
    //        return;
    //    }

    //    // Check in a loop if we are close enough to the current waypoint to switch to the next one.
    //    // We do this in a loop because many waypoints might be close to each other and we may reach
    //    // several of them in the same frame.
    //    reachedEndOfPath = false;
    //    // The distance to the next waypoint in the path
    //    float distanceToWaypoint;
    //    while (true)
    //    {
    //        // If you want maximum performance you can check the squared distance instead to get rid of a
    //        // square root calculation. But that is outside the scope of this tutorial.
    //        distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
    //        if (distanceToWaypoint < nextWaypointDistance)
    //        {
    //            // Check if there is another waypoint or if we have reached the end of the path
    //            if (currentWaypoint + 1 < path.vectorPath.Count)
    //            {
    //                currentWaypoint++;
    //            }
    //            else
    //            {
    //                // Set a status variable to indicate that the agent has reached the end of the path.
    //                // You can use this to trigger some special code if your game requires that.
    //                reachedEndOfPath = true;
    //                break;
    //            }
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    // Slow down smoothly upon approaching the end of the path
    //    // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
    //    var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

    //    // Direction to the next waypoint
    //    // Normalize it so that it has a length of 1 world unit
    //    Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
    //    // Multiply the direction by our desired speed to get a velocity
    //    Vector3 velocity = dir * speed * speedFactor;

    //    // Move the agent using the CharacterController component
    //    // Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
    //    float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
    //    if (distanceToTarget < targetRechedThreshold || distanceToTarget < attackDistance )
    //    {
    //        reachedEndOfPath = true;
    //        velocity = Vector2.zero;
    //    }
    //    UpdateMotor((Vector2)velocity);
    //    // If you are writing a 2D game you may want to remove the CharacterController and instead modify the position directly
    //    // transform.position += velocity * Time.deltaTime;
    //}
    //private void OnDrawGizmos()
    //{
    //    if (!showGizmo)
    //    {
    //        return;
    //    }
    //    Gizmos.DrawSphere(targetPosition, 0.05f);
    //    if (Application.isPlaying && targetPosition != null)
    //    {
    //        if (!reachedEndOfPath)
    //        {
    //            Gizmos.DrawSphere(targetPosition, 0.05f);

    //        }
    //    }

    //}

    public Vector2 GetDirectionToMove()
    {
        if (path == null)
        {
            return Vector2.zero;
        }
        float distanceToWaypoint;
        distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < nextWaypointDistance)
        {
            // Check if there is another waypoint or if we have reached the end of the path
            if (currentWaypoint + 1 < path.vectorPath.Count)
            {
                currentWaypoint++;
            }
            else
            {
                // Set a status variable to indicate that the agent has reached the end of the path.
                // You can use this to trigger some special code if your game requires that.
                reachedEndOfPath = true;
                return Vector2.zero;
            }

        }
        //var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
        Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        if (Vector2.Distance(transform.position, targetPosition) < targetRechedThreshold)
        {
            reachedEndOfPath = true;
            return Vector2.zero;
        }
        return dir;
    }
    private void OnDrawGizmos()
    {
        if (!showGizmo)
        {
            return;
        }
        Gizmos.DrawSphere(targetPosition, 0.05f);
        if (Application.isPlaying && targetPosition != null)
        {
            if (!reachedEndOfPath)
            {
                Gizmos.DrawSphere(targetPosition, 0.05f);

            }
        }
    }
}