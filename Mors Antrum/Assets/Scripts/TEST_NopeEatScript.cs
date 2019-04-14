using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_NopeEatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Meep"))
        {
            Debug.Log("Eat and count works");
            GameObject.Find("MeepCount").GetComponent<MeepCountScript>().meepCount++;
            Destroy(other.gameObject);
        }
    }
    
}
