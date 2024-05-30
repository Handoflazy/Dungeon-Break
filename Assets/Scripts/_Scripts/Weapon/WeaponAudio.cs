using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : PlayerAudio
{
    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletsClip = null, loadBulletClip=null;

    public void PlayerShootSound()
    {
       PlayClip(shootBulletClip);
    }
    public void PlayerNoBulletSound()
    {
       PlayClip(outOfBulletsClip);
    }
    public void PlayerLoadBulletSound()
    {
        PlayClip(loadBulletClip);
    }


}
