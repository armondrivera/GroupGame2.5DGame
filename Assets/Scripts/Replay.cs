using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public string curScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame(curScene);
        }
    }

    public void RestartGame(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
