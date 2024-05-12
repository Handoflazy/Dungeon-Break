using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    private bool collected = false;
    public UnityEvent OnOpenChest;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnOpen()
    {
        if (!collected)
        {
            collected = true;
            StartCoroutine(OpenChest());
        }
       
    }
    IEnumerator OpenChest()
    {
       audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        OnOpenChest?.Invoke();
    }
}
