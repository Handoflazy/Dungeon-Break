using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Item/ModifierStat/HealthModifider")]
public class CharacterHealthStatModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        if(character.TryGetComponent<Health>(out Health health))
        {
            health.AddHealth((int)val); 
        }
    }
}
