using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : PlayerAudio
{
    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletsClip = null;

    public void PlayerShootSound()
    {
       PlayClip(shootBulletClip);
    }
    public void PlayerNoBulletSound()
    {
       PlayClip(outOfBulletsClip);
    }

}
