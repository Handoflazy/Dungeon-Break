using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAudio : PlayerAudio
{
    [SerializeField]
    private AudioClip hitClip=null, dealthClip=null, voiceLineClip=null;

    public void PlayerHitSound()
    {
        PlayClipWithVariablePitch(hitClip);
    }

    public void PlayDeathSound()
    {
        PlayClipWithDefaultPitch(dealthClip);

    }

    public void PlayVoiceLineSound()
    {
        PlayClipWithVariablePitch(voiceLineClip);
    }
}
