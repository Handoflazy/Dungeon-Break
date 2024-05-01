using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    [SerializeField]
    private List<Feedback> feedbackToPlay = null;

    public void PlayFeedBack()
    {
        FinishfeedBack();
        foreach (var feedback in feedbackToPlay)
        {
            feedback.CreateFeedBack();
        }
    }

    private void FinishfeedBack()
    {
        foreach (var feedback in feedbackToPlay)
        {
            feedback.CompletePreviousFeedBack();
        }
    }
}
