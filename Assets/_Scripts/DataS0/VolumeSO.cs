using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VolumeSO : ScriptableObject
{
    [field: SerializeField]
    public float MasterVolume { get; set; } = 0;
    [field: SerializeField]
    public float MusicVolume { get; set; } = 0;
    [field: SerializeField]
    public float SFXVolume { get; set; } = 0;
        
}
