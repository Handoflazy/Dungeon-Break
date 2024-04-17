using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item, IWeapon
{
    protected Animator WeaponAnim;
    [SerializeField]
    public int damagePoint = 0;
    [SerializeField]
    public float pushForce = 0;
    public WeaponType WeaponType;

    [SerializeField]
    private WeaponInfor weaponInfor;
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public WeaponInfor GetWeaponInfo()
    {
        return weaponInfor;
    }
}
public enum WeaponType
{
    Melee,
    Staff,
    Range
}