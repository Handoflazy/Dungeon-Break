using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Feedback
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefautMatTime = .2f;

    private Material defaultMat;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        defaultMat = spriteRenderer.material;
    }
    public float GetRestoreMatTime()
    {
        return restoreDefautMatTime;
    }
    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefautMatTime);
        spriteRenderer.material = defaultMat;
    }
    public override void CreateFeedback()
    {
        StartCoroutine(FlashRoutine());
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
    }
}
