using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DissolveFeedback : Feedback
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float duration = 0.05f;
    [field: SerializeField]
    public UnityEvent DeathCallback { get; set; }

    public override void CompletePreviousFeedback()
    {
        if (spriteRenderer == null)
            return;
        spriteRenderer.DOComplete();
        spriteRenderer.material.DOComplete();
    }

    public override void CreateFeedback()
    {

        CompletePreviousFeedback();
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.material.DOFloat(0, ShaderConst.DISSOLVE, duration));
        if (DeathCallback != null)
        {
            sequence.AppendCallback(() => DeathCallback.Invoke());
        }
    }
}