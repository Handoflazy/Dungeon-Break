using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public abstract class PlayerAudio : PlayerSystem
{
    protected AudioSource audioSource;
    [SerializeField]
    protected float pitchRandomness = .05f;
    protected float basePitch;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(1,1+ pitchRandomness);
        audioSource.pitch = randomPitch;
        PlayClip(clip);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlayClipWithDefaultPitch(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.pitch = 1;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
