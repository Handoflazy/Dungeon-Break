using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharacterStatModifierSO : ScriptableObject
{
    public abstract bool AffectCharacter(GameObject character, float val);
}
