using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    //public GameObject Wall;


    void OnColliionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")) //wanted only the player to touch
        {

            if (col.gameObject.name == "block") //Stupid code won't work, it worked on everyone else but not this one
            {
                Debug.Log("Destroyed");
                Vanish();                       //trying to destroy test then timer added

            }

        }
    }

    void Vanish ()
    {
        Destroy(this.gameObject);

    }


}


   

