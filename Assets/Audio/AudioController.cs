using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    
     [Header("----------- Audio Source ----------")]
     [SerializeField] AudioSource musicSource;
     [SerializeField] AudioSource SFXSource;
     [SerializeField] AudioSource audioSource;


    [Header("----------- Audio Clip ----------")]
     public AudioClip background;
     public AudioClip sfx1;
     public AudioClip sfx2;
     public AudioClip sfx3;
     public AudioClip sfx4;

    [SerializeField]
    protected float pitchRandomness = .05f;
    protected float basePitch;

    private void Start()
     {
         musicSource.clip = background;
         musicSource.Play();
     }
     public void PlaySFX(AudioClip clip)
     {
         SFXSource.PlayOneShot(clip);
     }
    public void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        SFXSource.pitch = randomPitch;
        PlayClip(clip);
    }

    public void PlayClip(AudioClip clip)
    {
        SFXSource.Stop();
        SFXSource.clip = clip;
        SFXSource.Play();
    }



    //-------- Toturial Managaer Sound ---------
    /* public Sound[] musicSounds, sfxSounds;
     public AudioSource musicSource, sfxSource;

     public void PlayMusic(string name)
     {
         Sound s = Array.Find(musicSounds, x => x.Name == name);
         if (s == null)
         {
             Debug.Log("Sound Not Found");
         }
         else
         {
             musicSource.clip = s.clip;
             musicSource.Play();
         }
     }
     public void PlaySFX(string name)
     {
         Sound s = Array.Find(sfxSounds, x => x.Name == name);
         if (s == null)
         {
             Debug.Log("Sound Not Found");
         }
         else
         {
             sfxSource.PlayOneShot(s.clip);  
         }
     }  */
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
}
