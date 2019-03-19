using UnityEngine;

public class HeyImWalkingHere : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;
    private GameObject player;
    public string playerTag = "Player";


    private void Start()
    {
        target = Waypoints.points[0];
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            Player person = player.GetComponent<Player>();

            person.lastWaypoint();
        }
        else
        {
            wayPointIndex++;
            target = Waypoints.points[wayPointIndex];
        }
    }
}
