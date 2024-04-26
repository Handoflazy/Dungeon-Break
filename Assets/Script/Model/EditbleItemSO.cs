using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName ="Item/Editble")]
    public class EditbleItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Consume";
        [SerializeField]
        private List<ModifierData> modifierDatas = new List<ModifierData>();
        [field:SerializeField]
        public AudioClip ActionSFX { get; private set; }

        public AudioClip DropSFX => throw new NotImplementedException();

        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            foreach (ModifierData data in modifierDatas)
            {
                data.statModifier.AffectCharacter(character, data.value);
            }
            return true;
        }
    }

    public interface IDestroyableItem
    {
      
    }

    public interface IItemAction
    {
        public string ActionName { get; }
        public AudioClip ActionSFX { get; }
        public AudioClip DropSFX { get; }
        bool PerformAction(GameObject character, List<ItemParameter> itemState);

       
    }

    [Serializable]
    public class ModifierData
    {
        public CharacterStatModifierSO statModifier;
        public float value;
    }
}