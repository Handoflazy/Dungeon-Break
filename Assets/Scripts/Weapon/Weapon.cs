using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public WeaponType _weaponType { get; set; }
    public override void OnUse()
    {
        throw new System.NotImplementedException();
    }

}
public enum WeaponType
{
    Melee,
    Staff,
    Range
}