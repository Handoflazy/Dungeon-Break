using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ApplyWeaponParameterSO : ScriptableObject
{
    public abstract void AffectCharacter(GameObject Sender,GameObject character, float val);
}
