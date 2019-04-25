using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource soundPlayer;

    public AudioClip jump;
    public AudioClip slide;

    [Range(0.0f, 1.0f)] public float jumpVolume;
    [Range(0.0f, 1.0f)] public float slideVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        soundPlayer.PlayOneShot(jump, jumpVolume);
    }

    public void PlaySlideSound()
    {
        soundPlayer.PlayOneShot(slide, slideVolume);
    }
}
