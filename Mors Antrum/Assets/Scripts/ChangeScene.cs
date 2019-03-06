using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string NextLevel; //Type the correct scene name in the Inspector


    //When players collided with gameobject with script
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(NextLevel); //Load into scene

        }


    }
}
