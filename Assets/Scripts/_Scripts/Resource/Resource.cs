using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour
{
    [field:SerializeField]
    public ResourceDataSO ResourceData {  get; set; }
    private BoxCollider2D boxCollider2D;
    [field: SerializeField]
    private float timeSpawn = 0.5f;

    AudioSource audioSource;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator Start()
    {
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(timeSpawn);
        boxCollider2D.enabled = true;
    }
    public void PickUpResource()
    {
        StartCoroutine(DestroyCoroutine());
    }
    IEnumerator DestroyCoroutine()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }

}
