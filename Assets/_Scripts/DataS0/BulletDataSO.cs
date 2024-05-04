using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapons/Bullet Data")]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject bulletPrefab {  get; set; }
    [field: SerializeField, Range(1, 10)]
    public int Damage { get; set; } = 1;

    [field:SerializeField, Range(0, 10)]
    public float Friction { get; internal set; }
    [field: SerializeField,Range(1,100)]
    public float BulletSpeed { get; internal set; }
    [field: SerializeField]
    public bool Bounce { get; set; } = false;

    [field: SerializeField]
    public bool GoThrougHitable { get; set; } = false;


    [field: SerializeField]
    public bool IsRaycast { get; set; } = false;
    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }
    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }
    [field: SerializeField, Range(.1f, 20)]
    public float KnockBackPower { get; set; } = 1;
    [field: SerializeField, Range(.01f, 1f)]
    public float KnockBackDelay { get; set; } = 0;

}
