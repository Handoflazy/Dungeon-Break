using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField]
    private float freezeTimeDelay = .001f, unfreezeTimeDelay = .02f;

    [SerializeField, Range(0, 1)]
    private float timeFreezeValue = .2f;
    public override void CompletePreviousFeedback()
    {
        NguyenSingleton.Instance.GameManager.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        if(NguyenSingleton.Instance.GameManager)
            NguyenSingleton.Instance.GameManager.ModifyTimeScale(timeFreezeValue, freezeTimeDelay, () => NguyenSingleton.Instance.GameManager.ModifyTimeScale(1, unfreezeTimeDelay));
    }
}
