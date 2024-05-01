using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator WeaponAnim;
    public WeaponType WeaponType;
    public AgentParent weaponParent;
    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public WeaponInfor GetWeaponInfo()
    {
        throw new System.NotImplementedException();
    }
    public virtual void OnTriggerWeapon(GameObject target)
    {
        foreach (var item in weaponParent.itemCurrentState)
        {
            if (!item.applyParameter)
                return;
            item.applyParameter.AffectCharacter(gameObject, target, item.value);
        }
    }
}
public enum WeaponType
{
    Melee,
    Staff,
    Range
}