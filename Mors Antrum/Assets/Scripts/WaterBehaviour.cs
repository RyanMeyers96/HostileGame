using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBehaviour : MonoBehaviour
{
    public float waterSpeed;
    public GameObject grandMeep;

    // Start is called before the first frame update
    void Start()
    {
        waterSpeed = 0.01f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + waterSpeed, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == grandMeep)
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}
