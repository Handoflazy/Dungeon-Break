using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


[CreateAssetMenu(menuName = "Item/ParameterApplyEquipment/ApplyPushForce")]
public class ApplyForcePushParameterSO : ApplyWeaponParameterSO
{
    public override void AffectCharacter(GameObject Sender, GameObject character, float val)
    {
        if(character.TryGetComponent(out Rigidbody2D rb))
        {
            Vector2 direction = character.transform.position - Sender.transform.position;
            direction = direction.normalized;
            rb.AddForce(direction*val,ForceMode2D.Impulse);
        }
       

    }
}
