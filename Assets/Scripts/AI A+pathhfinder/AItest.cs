using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AItest : MonoBehaviour
{
    [Header("Pathfinding")]
    public float speed = 300f;
    public float nextWaypointDistance = 3f;
    public float pathUpdateSecond = 0.5f;
    [Header("Reference")]
    Path path;
    int currentWayPoint = 0;
    public bool reachEndOfPath = false;
    public Animator anim;
    protected Seeker seeker;
    Rigidbody2D rb;
    public Transform target;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(UpdatePath), 0, pathUpdateSecond);

    }
    protected virtual void UpdatePath()
    {
        if (target != null)
        {
            if (seeker.IsDone())
            {

                seeker.StartPath(transform.position, target.position, OnPathCompelete);
            }
        }
    }
    protected virtual void OnPathCompelete(Path p)
    {
        if (!p.error)
        {
            reachEndOfPath = false;
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    protected virtual void LateUpdate()
    {
        if (path == null)
        {
            return;
        }
        float distanceToWaypoint;
        distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (distanceToWaypoint < nextWaypointDistance)
        {
            // Check if there is another waypoint or if we have reached the end of the path
            if (currentWayPoint + 1 < path.vectorPath.Count)
            {
                currentWayPoint++;
            }
            else
            {
                // Set a status variable to indicate that the agent has reached the end of the path.
                // You can use this to trigger some special code if your game requires that.
                reachEndOfPath = true;
                return;
            }
        }
        var speedFactor = reachEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
        Vector2 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized*0.16f;
        Vector2 velocity = speed * speedFactor * dir;
        transform.position += (Vector3)(velocity * Time.deltaTime);
        if (rb.velocity.magnitude > 0)
        {
            print(velocity.magnitude);
            anim.SetFloat("speed_f", 0.3f);
        }
        else
            anim.SetFloat("speed_f", 0.0f);
       
        if (reachEndOfPath)
            return;
    }
}
