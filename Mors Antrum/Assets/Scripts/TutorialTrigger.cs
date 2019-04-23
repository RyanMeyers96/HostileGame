using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private Image tutorialImage;
    //private Transform imageappear;
    public Image uiImage;


    void OnTriggerEnter(Collider other) //collide with player with tutorial image appear
    {
        if (other.CompareTag("Player")) //Image appear to player when tag
        {
            //GameObject.Instantiate(imageappear, new Vector3(0, 0, 0), Quaternion.identity);
            tutorialImage.enabled = true;
            Destroy(uiImage.gameObject, 3);
            Destroy(gameObject, 3);






        }
    }


    /*void OnTriggerExit(Collider other) //image disappear when player exit the triggerbox
    {

        if (other.CompareTag("Player"))
        {
            tutorialImage.enabled = false;
            Destroy(gameObject, 3);    
        }
    }*/


}



