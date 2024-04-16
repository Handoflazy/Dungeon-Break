using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFade : MonoBehaviour
{
    [SerializeField]
    private Image fadeScreen;
    [SerializeField]
    private float fadeSpeed = 1f;

    private IEnumerator fadeRountine;

    public void FadeToBlack()
    {
        if(fadeRountine != null)
        {
            StopCoroutine(fadeRountine);
        }
        print("load exit scene");
        fadeRountine = FadeRoutine(1);
        StartCoroutine(fadeRountine);
    }
    public void FadeToClear()
    {
        if (fadeRountine != null)
        {
            StopCoroutine(fadeRountine);
        }
        fadeRountine = FadeRoutine(0);
        StartCoroutine(fadeRountine);
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeScreen.color.a, targetAlpha)){
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }
}
