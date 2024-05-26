using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPController : MonoBehaviour
{
    protected Duration duration;
    [SerializeField]
    protected int recoverAmount = 20;
    
    [SerializeField]
    protected AudioClip takeSound;

    protected AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null) { print(1); }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        int playerLayer = LayerMask.NameToLayer("Player"); // get Player's layer

        if (other.gameObject.layer == playerLayer)
        {
            duration = other.GetComponent<Duration>();
            if (duration.CurrentDuration == duration.MaxDuration) return;
            audioSource.PlayOneShot(takeSound);
            duration.RefillDuration(recoverAmount);
            Destroy(gameObject);
        }
    }
}
