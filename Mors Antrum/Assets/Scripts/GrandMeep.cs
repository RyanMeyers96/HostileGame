using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandMeep : MonoBehaviour
{
    
    public delegate void SummonLight(GameObject light);
    public static event SummonLight OnSummonedLight;
    [SerializeField] private float speedMult;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject lightPrefab;
    private GameObject light;
    public int meepFollowers;
    [SerializeField] private GameObject GMLight;
    public float time = 0;

    

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && time <= 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {                
                light = Instantiate(lightPrefab, new Vector3(hit.point.x, hit.point.y, 1), new Quaternion(0, 0, 0, 0));
                if (OnSummonedLight != null)OnSummonedLight(light);
                time = 1;
            }         
        }
        if (Input.GetMouseButtonUp(0)) 
        {
        Destroy(light);
        
        }
        time -= Time.deltaTime;
        GMLight.GetComponent<Light>().range = meepFollowers + 3;
        
        transform.Translate(Input.GetAxis("Horizontal")/speedMult, Input.GetAxis("Vertical")/speedMult,0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Nope"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}

