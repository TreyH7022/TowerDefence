using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    public float baseSpeed = 3f;

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

    public void Initialize(Transform[] assignedWaypoints, float speedMultiplier = 1f)
    {
        waypoints = assignedWaypoints;

        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints not assigned!");
            return;
        }

        speed = baseSpeed * speedMultiplier;

        transform.position = waypoints[0].position;
    }

    void FollowPath()
    {
        if (waypointIndex >= waypoints.Length)
        {
            GameManager.instance.TakeDamage(1);
            Destroy(gameObject);
            if (GameManager.instance.playerHealth <= 0)
            {
                GameManager.instance.GameOver();
            }
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