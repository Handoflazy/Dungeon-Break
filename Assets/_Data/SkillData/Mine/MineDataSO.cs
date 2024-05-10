using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill / MineData")]
public class MineDataSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite MineImage;

    [field: SerializeField]
    public GameObject ExplosionPrefab { get; set; }

    [field: SerializeField, Range(0.5f,2)]
    public float WaitTime { get; set; }

    [field: SerializeField, Range(10,50)]
    public int ExplosionPower { get; set; }

    [field: SerializeField, Range(2,10)]
    public float Knockback { get ; set ; }

    [field: SerializeField, Range(0.16f, 1.28f)]
    public float ExplosionRadius { get; set ; }

}
