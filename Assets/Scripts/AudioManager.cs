using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void PlayAudio(AudioClip clip,float volume)
    {
      audioSource.PlayOneShot(clip);
      audioSource.volume = volume;
    }
    public void PlayBackGround(AudioClip clip, float volume)
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume = volume;
    }


}
