using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;

    private int waypointIndex = 0;

    void Start() 
    {
       /* if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError(gameObject.name + " has no waypoints!");
            Destroy(gameObject);
            return;
        }

        transform.position = waypoints[0].position; */
    }

    void Update()
    {
        FollowPath();
    }

    public void Initialize(Transform[] assignedWaypoints)
    {
        waypoints = assignedWaypoints;

        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints not assigned!");
            return;
        }

        transform.position = waypoints[0].position;
    }

    void FollowPath()
    {
        if (waypointIndex >= waypoints.Length)
        {
            Destroy(gameObject); // Enemy reached end
            return;
        }

        Transform target = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            waypointIndex++;
        }
    }
}