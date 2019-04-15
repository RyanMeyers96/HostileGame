using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class MeepEating : MonoBehaviour
{
    
    private GameObject objTrigger;
    private MeepBehavior eatMeep;
    private GrandMeep eatPlayer;
    [SerializeField] private GameObject mouth;

    public int meepsWanted = 1; //how many meeps the nope wants to eat
    public int meepsHad;//how many meeps the nope has eaten

    //animation related
    public bool eat;
    public bool stop;
    
    private void OnTriggerEnter(Collider other)
    {
        //everytime a meep enters its mouth, it eats the meep

        objTrigger = other.gameObject;
        eatMeep = objTrigger.GetComponent<MeepBehavior>();
        eatPlayer = objTrigger.GetComponent<GrandMeep>();
        
        if (eatMeep != null)
        {
            eat = true;
            meepsHad++;
            GameObject.Find("MeepCount").GetComponent<MeepCountScript>().meepCount++;
            eatMeep.myState = eatMeep.dead;
            eatMeep.nope = mouth;
            eat = false;
        }

        if (eatPlayer != null)
        {
            eat = true;
            //eat player
            eat = false;
        }
    }

   

    private void Update()
    {
        if (meepsHad == meepsWanted)
        {
            stop = true;
        }

    }

}

