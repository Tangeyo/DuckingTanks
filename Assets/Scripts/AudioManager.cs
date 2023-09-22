using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        audioSource.Play();
    }

    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }
}

