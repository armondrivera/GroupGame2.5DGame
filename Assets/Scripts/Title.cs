using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public BGM backgroundmusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Level1");
            Object.DontDestroyOnLoad(backgroundmusic.soundPlayer);
            Object.DontDestroyOnLoad(backgroundmusic.bgm);
        }
    }
}
