using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="MovementData",menuName = "Agent/MovementData")]
public class MovementDataS0 : ScriptableObject
{
    [Range(0,10)]
    public float maxSpeed =1;
    [Range(0.1f, 100)]
    public float acceleration=1, deceleration=1;

}
