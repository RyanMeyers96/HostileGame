using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] Waypoints;
    public float speed = 2;

    public int CurrentPoint = 0;

    //private IEnumerator coroutine;
    public float DelayTime;
    public float CurrentTimer;

    void Start()
    {
        CurrentTimer = DelayTime;
    }
    void Update()
    {
        if (transform.position != Waypoints[CurrentPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        }

        if (transform.position == Waypoints[CurrentPoint].transform.position)
        {
            //StartCoroutine("Wait");
            Delay();
            
        }


        if (CurrentPoint >= Waypoints.Length)
        {
            CurrentPoint = 0;
        }
    }

    private void Delay()
    {
        
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer <=0)
        {
            CurrentPoint += 1;
            CurrentTimer = DelayTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);   // Probably better way
        }
    }
}