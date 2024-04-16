using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crate : Fighter
{
    public override void Death()
    {
        NguyenSingleton.Instance.FloatingTextManager.Show("Bro is dead", 30, UnityEngine.Color.red, transform.position, Vector3.zero, 0.5f);
    }
}
