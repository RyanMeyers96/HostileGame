using UnityEngine;
using UnityEngine.SceneManagement;

public class MeepCountScript : MonoBehaviour
{
    public int meepCount;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        meepCount = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
