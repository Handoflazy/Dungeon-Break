using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Item/ModifierStat/DurationModifider")]
public class CharacterDurationStatModifier : CharacterStatModifierSO
{
    public override bool AffectCharacter(GameObject character, float val)
    {
        if (character.TryGetComponent<Duration>(out Duration duration))
        {
            if (!duration.IsFull)
            {
                duration.RefillDuration((int)val);
                return true;
            }
               
        }
        return false;
    }
}
