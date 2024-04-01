using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    public UnityEvent OnAnimationEventTrigger, OnSwingComplete, ActivateEffect;
    public void TriggerEvent()
    {  
        OnAnimationEventTrigger?.Invoke();
        print(1);
    }
    public void TriggerSwingComplete()
    {
        OnSwingComplete?.Invoke();
    }
    public void TriggerActivateEffect()
    {
        ActivateEffect?.Invoke();
    }
}
