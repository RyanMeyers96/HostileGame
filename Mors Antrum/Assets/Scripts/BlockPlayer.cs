using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    //GameObject Wall;
    //Collider myCollider;
    


    /*private void Start()
    {
        //GameObject[] gameObjects;
        //gameObjects = GameObject.FindGameObjectsWithTag("block");
        //gameObject.SetActive(false);

        myCollider = GetComponent<Collider>();
        
    }



    /*void OnColliionEnter(Collision col)
    {
         /*if (col.gameObject.name == "Player") //Stupid code won't work, it worked on everyone else but not this one
            {
                Debug.Log("Destroyed");
                //Vanish();                       //trying to destroy test then timer added

            }

        if (col.gameObject.tag == "block") //wanted only the player to touch
        {
            Debug.Log("Destroyed");
            Wall = col.gameObject;
            Destroy(this.gameObject);
        }

        /*if (col.gameObject.CompareTag("Player")) //wanted only the player to touch
        {

        }*/

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            //GameObject.Instantiate(imageappear, new Vector3(0, 0, 0), Quaternion.identity);

            Destroy(this.gameObject, 3);




        }

    }

            /*void Vanish ()
    {
        Destroy(this.gameObject);

    }*/


}


   

