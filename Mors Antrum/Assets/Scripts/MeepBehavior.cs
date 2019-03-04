using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeepBehavior : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject grandMeep;
    private bool following = false;
    private GameObject light;
    
    

    private enum state
    {
        followGM,
        followLight,
        idle,
        eaten
    }

    public float testDistance;
    [SerializeField]
    private state myState = state.idle;
       // Start is called before the first frame update
       void Start()
       {
           navMeshAgent = GetComponent<NavMeshAgent>();
           grandMeep = GameObject.FindWithTag("Player");
          
       }

       public void LightSummoned(GameObject newLight)
       {       
            light = newLight;
            if (light != null) myState = state.followLight;
            //return null;
       }

       // Update is called once per frame
       void Update()
       {
       CheckFollower();
           switch (myState)
           {           
               case state.idle:
               GrandMeep.OnSummonedLight -= LightSummoned;
                   if (CheckDistance())
                   {
                       CheckSight();
                   }
                   Move(gameObject);
                   break;
               case  state.followGM:
                   if (CheckDistance())
                   {
                        CheckSight();
                   }
                   GrandMeep.OnSummonedLight += LightSummoned;
                   //check if summoned light will be held down or one time trigger event if so need seperate state for it
                   Move(grandMeep);
                   break;
               case state.followLight:
                   GrandMeep.OnSummonedLight -= LightSummoned;
                   if (light) Move(light);
                   else myState = state.idle;
                   break;
               case state.eaten:
                   GrandMeep.OnSummonedLight -= LightSummoned;
                   Destroy(gameObject);
                   break;
           }
       }

       #region CheckingCode

       private void CheckFollower()
       {
           if (myState == state.followGM)
           {
               if (!following) 
               {
                   grandMeep.GetComponent<GrandMeep>().meepFollowers++;
                   following = true;
               }
           } else
           {       
               if (following) 
               {
                   grandMeep.GetComponent<GrandMeep>().meepFollowers--;
                   following = false;
               }
           }
       }
       private void CheckSight()
       {
           RaycastHit hit;
           if (Physics.Linecast(transform.position, grandMeep.transform.position, out hit))
           {              
               if (hit.transform.gameObject == grandMeep)
               {
                    myState = state.followGM;
                    return;
               }
               myState = state.idle;
           }
       }

       private bool CheckDistance()
       {           
           if (Vector3.Distance(gameObject.transform.position, grandMeep.transform.position) > testDistance)
           {
               myState = state.idle;
               return false;
           }
           return true;
       }
       
       #endregion
       private void Move(GameObject target)
       {
           navMeshAgent.destination = target.transform.position;
       }
    /*  collision with grand meep? check for light?
    *   add meeps to event cast from grand meep and target grand meep
    */



    /*  Grand meep Event
    *   when Grand meep makes light at other point change target of meep
    */

    /*  Movement
    *   joined to grandmeeps event
    *   move toward target location
    */

    /*     check if on platform
     *     when on platform disable navmesh agent swap state and activate platform
     *     when platform stops reenable mesh and change state again.
     */
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == grandMeep)
        {
            Physics.IgnoreCollision(grandMeep.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }
}
