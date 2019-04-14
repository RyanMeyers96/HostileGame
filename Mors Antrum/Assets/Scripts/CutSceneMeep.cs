using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneMeep : MonoBehaviour
{
    public Transform[] Waypoints;
    public float speed = 2f;

    public int CurrentPoint = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // This part here tells the platform to move towards the position of the current waypoint
        if (transform.position != Waypoints[CurrentPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        }

        // This checks if the 'Current Point' counter is higher than the actual amount of Waypoints, then resets it if it is
        if (CurrentPoint >= Waypoints.Length)
        {

            CurrentPoint = 0;
        }

        // So we have to update the counter for the waypoints so that it keeps moving to the next location :D

    }
}
