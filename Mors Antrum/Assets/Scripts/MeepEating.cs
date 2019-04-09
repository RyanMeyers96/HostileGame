using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeepEating : MonoBehaviour
{

    private GameObject objTrigger;
    private MeepBehavior eatMeep;
    //public List<MeepBehavior> meepsToBeDead;  - no longer needed
    private GrandMeep eatPlayer;
    [SerializeField] private GameObject mouth;

    public int meepsWanted = 1; //how many meeps the nope wants to eat
    public int meepsHad;//how many meeps the nope has eaten
    
    
    private void OnTriggerEnter(Collider other)
    {
        //everytime a meep enters its mouth, it eats the meep

        objTrigger = other.gameObject;
        eatMeep = objTrigger.GetComponent<MeepBehavior>();
        eatPlayer = objTrigger.GetComponent<GrandMeep>();
        
        if (eatMeep != null)
        {
            //make meeps jump
            meepsHad++;
            GameObject.Find("MeepCount").GetComponent<MeepCountScript>().meepCount++;
            eatMeep.myState = eatMeep.dead;
            eatMeep.nope = mouth;
            //meepsToBeDead.Add(objTrigger.GetComponent<MeepBehavior>()); - no longer useful, now that each meep is being eaten one at a time
        }

        if (eatPlayer != null)
        {
            //the player is eaten by the meep
        }
    }

    /*  No longer useful now that the meeps are being eaten one at a time
    private void OnTriggerExit(Collider other)
    {
        //everytime someone exits its mouth it checks if it is a meep, if yes meepsHad goes down
        
        objTrigger = other.gameObject;
        
        if (objTrigger.GetComponent<MeepBehavior>() != null)
        {
            meepsHad--;
            meepsToBeDead.Remove(objTrigger.GetComponent<MeepBehavior>());
        }
    }*/

    private void Update()
    {
        /*check if the nope can eat now - no longer needed
        if (meepsHad == meepsWanted)
        {
            //insert animation for eating
            for (int i = 0; i <= meepsWanted; i++)
            {
                meepsToBeDead[i].myState = meepsToBeDead[i].dead;
            }

            Leave();
        }*/

        if (meepsHad == meepsWanted)
        {
            Leave();
        }
    }

    private void Leave()
    {
        //animation for leaving
        //more transform backwards
        //delete self once done
    }
}

