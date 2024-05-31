using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


[CreateAssetMenu(menuName ="Item/ModifierStat/HealthModifider")]
public class CharacterHealthStatModifierSO : CharacterStatModifierSO
{
    public override bool AffectCharacter(GameObject character, float val)
    {
        if(character.TryGetComponent<Health>(out Health health))
        {
            if(health.isFull)
            {
                return false;
            }
            health.AddHealth((int)val);
            return true;
        }
        return false;
    }
}
