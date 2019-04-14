using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NopeAnimation : MonoBehaviour
{

    public Rigidbody rb;
    
    private Animator NopeAnimator;
    //reads from meep eating so it knows when to eat
    public MeepEating eating;
    
    public int forward = 50;
    public int back = 50;

    public bool up = true;
    

    private void Awake()
    {
        NopeAnimator = GetComponent<Animator>();
        NopeAnimator.SetBool("Walk", true);

        eating = GetComponentInChildren<MeepEating>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (eating.eat == true)
        {
            NopeAnimator.SetBool("Eat", true);
        }

        else
        {
            NopeAnimator.SetBool("Eat", false);
        }

        //resets times when need be
        if (forward <= 0)
        {
            back = 0;
            forward = 1;
            up = false;
        }

        if (back >= 100)
        {
            back = 89;
            forward = 100;
            up = true;
        }

        //move forward while you're meant to move forward
        if ((eating.stop == false) && (eating.eat == false) && (forward > 0) && (up == true))
        {

            transform.position += -transform.forward * 1.5f * Time.deltaTime;
            forward--;
        }

        //move back while you're meant to move back
        if ((eating.stop == false) && (eating.eat == false) && (back < 100) && up == false)
        {
            transform.position += transform.forward * 1.5f * Time.deltaTime;
            back++;
        }

        if (eating.stop == true)
        {
            NopeAnimator.SetBool("Walk", false);
            NopeAnimator.SetBool("Eat", false);
        }


    }
}
