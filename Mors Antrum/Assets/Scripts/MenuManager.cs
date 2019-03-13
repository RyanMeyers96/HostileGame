using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //Start new game by clicking 'Play'
    public void StartNewGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    //Quit game to exit
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
