using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        meepFollowers = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {                
                light = Instantiate(lightPrefab, new Vector3(hit.point.x, hit.point.y, 1), new Quaternion(0, 0, 0, 0));
                if (OnSummonedLight != null)OnSummonedLight(light);
            }         
        }
        if (Input.GetMouseButtonUp(0)) Destroy(light);
        
        transform.Translate(Input.GetAxis("Horizontal")/speedMult, Input.GetAxis("Vertical")/speedMult,0);
    }
    
    private void UpdateLight()
    {
    /*
    take number of meep followers
    get light source reference
    set either lintensity or range to be increase by a ratio depended on amount of meeps
    possible 10 % increase for every meep?
    */
    }
}
