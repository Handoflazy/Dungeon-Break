using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCinemachineFeedback : Feedback
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField]
    [Range(0, 5)]
    private float amplitude = 1, intensify = 1;
    [SerializeField, Range(0, 1)]
    private float duration = .1f;
    [SerializeField]
    private CinemachineBasicMultiChannelPerlin noise;
    private void Start()
    {
        if (!cinemachineVirtualCamera)
        {
            cinemachineVirtualCamera = GameObject.Find("VIrtual Main Camera").GetComponent<CinemachineVirtualCamera>();
        }
        noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0;
    }

    public override void CreateFeedback()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensify;
        StartCoroutine(ShakeCoroutine());
    }
    IEnumerator ShakeCoroutine()
    {
        for (float i = duration; i > 0; i-=Time.deltaTime)
        {
            noise.m_AmplitudeGain = Mathf.Lerp(0,amplitude, i/duration);
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
    }
}
