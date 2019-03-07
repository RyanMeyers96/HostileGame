using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeepEating : MonoBehaviour
{

    public GameObject objTrigger;
    public List<MeepBehavior> meepsToBeDead;

    public int meepsWanted = 1; //how many meeps the nope wants to eat
    public int meepsHad;//how many meeps the nope has in its mouth
    
    
    private void OnTriggerEnter(Collider other)
    {
        //everytime someone enters its mouth it checks if it is a meep, if so meeps had goes up

        objTrigger = other.gameObject;
        
        if (objTrigger.GetComponent<MeepBehavior>() != null)
        {
            meepsHad++;
            meepsToBeDead.Add(objTrigger.GetComponent<MeepBehavior>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //everytime someone exits its mouth it checks if it is a meep, if yes meepsHad goes down
        
        objTrigger = other.gameObject;
        
        if (objTrigger.GetComponent<MeepBehavior>() != null)
        {
            meepsHad--;
            meepsToBeDead.Remove(objTrigger.GetComponent<MeepBehavior>());
        }
    }

    private void Update()
    {
        //check if the nope can eat now
        if (meepsHad == meepsWanted)
        {
            //insert animation for eating
            for (int i = 0; i <= meepsWanted; i++)
            {
                meepsToBeDead[i].myState = meepsToBeDead[i].dead;
            }

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
