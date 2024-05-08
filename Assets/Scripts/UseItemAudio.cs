using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemAudio : PlayerAudio
{
    [SerializeField]
    private AudioClip useAmmoBox = null, useMedikitBox = null;

    public void PlayReloadSound()
    {
        PlayClip(useAmmoBox);
    }
    public void PlayHealSound()
    {
        PlayClip(useMedikitBox);
    }
}
