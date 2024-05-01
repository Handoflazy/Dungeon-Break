using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpriteFeedback : Feedback
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private float flashTime = 0.1f;

    [SerializeField]
    private Material flashMaterial = null;

    private Shader originalMetarialShader;

    private void Start()
    {
        originalMetarialShader = spriteRenderer.material.shader;
    }

    public override void CompletePreviousFeedBack()
    {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMetarialShader;
    }

    public override void CreateFeedBack()
    {
        CompletePreviousFeedBack();
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            originalMetarialShader = flashMaterial.shader;
        }
        spriteRenderer.material.SetInt("_MakeSolidColor", 1);
        StartCoroutine(WaitBeforeChangingBack());
    }
    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(flashTime);
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        }
        else
        {
            originalMetarialShader = spriteRenderer.material.shader;
        }
    }
}
