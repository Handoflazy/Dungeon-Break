using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeLineBoss : MonoBehaviour
{
    public GameObject timeline;
    public GameObject fence;
    public GameObject boss;
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSFX;
    public AudioClip clipSound;
    public AudioClip soundIntro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerMovermentCollider"))
        {
            timeline.SetActive(true);
            fence.SetActive(true);
            ChangeMusic();
        }
    }
    private void Update()
    {
        if (boss.activeSelf == false)
        {
            fence.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void ChangeMusic()
    {
        //AudioClip anotherClip = Resources.Load<AudioClip>("12 Pixel Tracks/Pixel 8");

        audioSourceMusic.clip = clipSound;
        audioSourceMusic.Play();
        audioSourceSFX.PlayOneShot(soundIntro);
        /*if (audioSource.isPlaying)
        {
            audioSource.Play();
        }*/
    }
}
