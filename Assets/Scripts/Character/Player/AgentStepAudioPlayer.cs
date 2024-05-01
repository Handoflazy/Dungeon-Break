using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStepAudioPlayer : PlayerAudio
{

    [SerializeField]
    protected AudioClip stepClip;
    public void PlayStepSound()
    {
      PlayClipWithVariablePitch(stepClip);
    }
}
