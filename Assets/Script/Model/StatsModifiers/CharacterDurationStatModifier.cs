using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Item/ModifierStat/DurationModifider")]
public class CharacterDurationStatModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        if (character.TryGetComponent<Duration>(out Duration duration))
        {
            duration.RefillDuration((int)val);
        }
    }
}
