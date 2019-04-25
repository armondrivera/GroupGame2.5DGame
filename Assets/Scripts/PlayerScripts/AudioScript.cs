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

    private float pitch = 1.0f;
    private float spare;
    public float minPitchVal;
    public float maxPitchVal;

    private void Awake()
    {
        spare = pitch;
    }
    private void Update()
    {
        pitch = Random.Range(minPitchVal, maxPitchVal);
    }

    public void PlayJumpSound()
    {
        soundPlayer.PlayOneShot(jump, jumpVolume);
        soundPlayer.pitch = pitch;
    }

    public void PlaySlideSound()
    {
        soundPlayer.PlayOneShot(slide, slideVolume);
        soundPlayer.pitch = spare;
    }
}
