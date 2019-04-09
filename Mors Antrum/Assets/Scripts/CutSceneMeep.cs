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
        if (transform.position != Waypoints[CurrentPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);

        }

        if (CurrentPoint >= Waypoints.Length)
        {

            CurrentPoint = 0;
        }
    }
}
