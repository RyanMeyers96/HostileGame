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

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Debug.Log("detect when down Here");
                light = Instantiate(lightPrefab, new Vector3(hit.point.x, hit.point.y, 1), new Quaternion(0, 0, 0, 0));
                if (OnSummonedLight != null)OnSummonedLight(light);
            }         
        }
        if (Input.GetMouseButtonUp(0)) Destroy(light);
        
        transform.Translate(Input.GetAxis("Horizontal")/speedMult, Input.GetAxis("Vertical")/speedMult,0);
    }
}
