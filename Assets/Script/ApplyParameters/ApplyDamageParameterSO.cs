using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ParameterApplyEquipment/ApplyDamage")]
public class ApplyDamageParameterSO : ApplyWeaponParameterSO
{
    public override void AffectCharacter(GameObject Sender, GameObject character, float val)
    {
        if (character.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage((int)val);
        }
    }
}
