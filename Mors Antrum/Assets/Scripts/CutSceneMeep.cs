using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneMeep : MonoBehaviour
{
    public Transform[] Waypoints;
    public float speed = 2f;
    public float timer;
    public int CurrentPoint = 0;

    private GameObject sphereShader;

    // Start is called before the first frame update
    void Start()
    {
        sphereShader = GameObject.FindGameObjectWithTag("Sphere");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(Waypoints[CurrentPoint]);

        // This part here tells the platform to move towards the position of the current waypoint
        if (transform.position != Waypoints[CurrentPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        }


        if (transform.position == Waypoints[CurrentPoint].transform.position)
        {
            CurrentPoint++;

        }

        // This checks if the 'Current Point' counter is higher than the actual amount of Waypoints, then resets it if it is
        if (CurrentPoint >= Waypoints.Length)
        {

            CurrentPoint = 0;
        }

        // So we have to update the counter for the waypoints so that it keeps moving to the next location :D

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            sphereShader.SetActive(false);
        }

        if(timer <= -10f)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

    }
}
