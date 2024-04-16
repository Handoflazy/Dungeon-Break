using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class WeaponInfor : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCoolDown;
}
