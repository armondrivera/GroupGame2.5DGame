using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public AudioSource soundPlayer;

    public AudioClip bgm;
    [Range(0.0f, 1.0f)] public float bgmVol;

    // Start is called before the first frame update
    void Awake()
    {
        
        soundPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Object.DontDestroyOnLoad(soundPlayer);
        Object.DontDestroyOnLoad(bgm);
    }
}
