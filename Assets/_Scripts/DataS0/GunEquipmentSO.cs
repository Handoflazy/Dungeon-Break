using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="ItemEquipment")]
public class GunEquipmentSO : ScriptableObject
{
    [field:SerializeField]
    public GameObject WeaponPrefab { get; set; } = null;
    [field: SerializeField]
    public int BulletNumber { get; set; } = 0;
    public AudioClip actionSFX = null;
    
}
