using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public GameObject PauseScreenUI;
    public static bool GamePaused = false;

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKeyDown( KeyCode.Escape ) ){
            if( GamePaused ){
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        PauseScreenUI.SetActive( false );
        Time.timeScale = 1f;
        GamePaused = false; 
    }

    public void Pause()
    {
        PauseScreenUI.SetActive( true );
        Time.timeScale = 0f;
        GamePaused = true;        

    }

    public void Restart()
    {

        PauseScreenUI.SetActive( false );
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene( "Scene" );

    }

    public void ExitGametoMain()
    {

        PauseScreenUI.SetActive( false );
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene( "Menu" );

    }
}
