using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneRandomVariant : MonoBehaviour
{
    public string[] possibleLevels;// allows list of scene names to be accessed
    
    void OnTriggerEnter(Collider other)
    {
        int temp = Random.Range(0, possibleLevels.Length);// selects random string from list
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(possibleLevels[temp]); //Load into scene
        }
    }
}
