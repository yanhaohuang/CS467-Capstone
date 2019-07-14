using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene( "Scene" );
    }

    public void EndGame()
    {
        Debug.Log("We are quitting. Comment this out as we build.");
        Application.Quit();
    }
}
