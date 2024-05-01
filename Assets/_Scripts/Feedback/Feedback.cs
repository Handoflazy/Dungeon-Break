using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void CreateFeedBack();
    public abstract void CompletePreviousFeedBack();

    protected virtual void OnDestroy()
    {
        CompletePreviousFeedBack();
    }
}
