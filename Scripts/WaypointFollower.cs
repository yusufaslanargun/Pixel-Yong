using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    [SerializeField]
    private bool isSetAutomatically = false, isVertical = false;
    [SerializeField]
    private float moveSpeed = 4f, range = 4f;

    private int waypointIndex = 0;
    void Start()
    {
        if (isSetAutomatically)
        {
            if (isVertical)
            {
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i].transform.position = new Vector3(transform.position.x, transform.position.y + i * range);
                }
            }
            else
            {
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i].transform.position = new Vector3(transform.position.x + i * range, transform.position.y);
                }
            }
        }
    }

    void Update()
    {
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * moveSpeed);
    }
}
