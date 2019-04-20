using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject pauseMenuUI;

    public string sceneToLoad;

   // public string curScene;

   // public GameObject Player;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume ();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



    //Resets current level
    //public void Reset()
    //{
       // SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
       // Time.timeScale = 1f;
       //// RestartGame(curScene);
        //Debug.Log("Game is resetting");   
   // }


    public void RestartGame(string sceneToLoad)
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }

    //public void Controls()
    //{
    //    LoadControls(curScene);
    //}

    //public void LoadControls(string sceneToLoad)
    //{
    //    SceneManager.LoadScene(sceneToLoad); 
   // Debug.Log("Loading Controls...");
    //}



    //public void LoadMenu()
    //{
    //Time.timeScale = 1f;
    //SceneManager.LoadScene("Menu");
    //Debug.Log("Loading menu...");
    // }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting game...");
            }
}
