using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public string levelName;

    bool isAlive = true;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>();
        levelName = SceneManager.GetActiveScene().name;
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
        
        if(isAlive)
        transform.Translate(Input.GetAxis("Horizontal")/speedMult, Input.GetAxis("Vertical")/speedMult,0);
    }

    IEnumerator Death()
    {
        isAlive = false;

        //visuals
        //maybe timeline? maybe animation? at least fade/particle/etc

        //TEMP - Ed did this 
        float t = 0;
        while (t < 0.5)
        {
            GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color + new Color(0, 0, 0, 0.05f);
            t += Time.deltaTime;
            yield return null;
        }
        while (t < 2)
        {
            GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color - new Color(0, 0, 0, 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        //ENDTEMP

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        yield return null;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Nope"))
        {
            StartCoroutine("Death");
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}

