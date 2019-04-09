using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuObject;
    public GameObject creditsObject;
    public AudioSource Source;
    [SerializeField] private AudioClip[] easterEggs;

    //Start new game by clicking 'Play'
    public void StartNewGame()
    {
        menuObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    //Set credits menu to active
    public void Credits()
    {
        menuObject.GetComponent<AudioSource>().Play();
        
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);

    }

    //Go back from Credits page
    public void BackButton()
    {
        menuObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("Credits");
    }


    //Quit game to exit
    public void QuitGame()
    {
        menuObject.GetComponent<AudioSource>().Play();
        Debug.Log("Quit");
        Application.Quit();
    }


    //Clicking on Holly Benton's name in the credits
    public void ClickOnEasterEgg()
    {
        Debug.Log("Easter eggs work");
        EasterEggs(easterEggs);
    }


    private void EasterEggs(AudioClip[] sound)
    {
        Source.clip = sound[Random.Range(0, sound.Length)];
        Source.Play();
    }

}
