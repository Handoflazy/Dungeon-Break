using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetector : MonoBehaviour
{
    [Range(0,1), SerializeField]
    private float transparentAmount = 0.8f;

    [SerializeField]
    private float fadeTime =  0.4f;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
         
            if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, transparentAmount));
            }
            else if(tilemap)
            {
                StartCoroutine(FadeRoutineTileMap(tilemap, fadeTime, tilemap.color.a, transparentAmount));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1));
            }
            else if (tilemap)
            {
                StartCoroutine(FadeRoutineTileMap(tilemap, fadeTime, tilemap.color.a, 1));
            }
        }
    }
    IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime,float startValue, float targetTransparent)
    {
        float elapsedTime = 0;
        while(elapsedTime < fadeTime)
        {
            elapsedTime +=Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue,targetTransparent,elapsedTime/fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            yield return null;
        }
    }
    IEnumerator FadeRoutineTileMap(Tilemap tilemap, float fadeTime, float startValue, float targetTransparent)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparent, elapsedTime / fadeTime);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newAlpha);
            yield return null;
        }
    }


}
