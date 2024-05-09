using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAudio : PlayerAudio
{
    [SerializeField]
    private AudioClip dashClip = null;
    [SerializeField]
    private AudioClip mineClip = null;
    [SerializeField]
    private AudioClip explosionClip = null;
    [SerializeField]
    private AudioClip enhanceClip = null;

    public void DashSound()
    {
        PlayClip(dashClip);
    }
    public void MineSound()
    {
        PlayClip(mineClip);
    }
    public void ExplodeSound()
    {
        PlayClip(explosionClip);
    }
    public void EnhanceClip()
    {
        PlayClip(enhanceClip);
    }
}
