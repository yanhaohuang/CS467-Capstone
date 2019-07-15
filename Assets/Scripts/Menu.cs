using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /*
        Click Handler to the "Play" button in the main menu
        If the player clicks this element, this click handler fires and the gameplay scene loads
     */
    public void StartGame()
    {
        SceneManager.LoadScene( "Scene" );
    }

    /*
        Click Handler to the "Quit" button in the main menu
        If the player clicks this element, the application closes. 
        Since we don't have the application built yet, this won't work
     */
    public void EndGame()
    {
        Debug.Log("We are quitting. Comment this out as we build.");
        Application.Quit();
    }
}
