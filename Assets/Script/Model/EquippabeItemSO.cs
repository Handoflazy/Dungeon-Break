using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Item/Equipment")]
    public class EquippabeItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        [field: SerializeField]
        public GameObject WeaponPrefap { get; private set; }


        [field: SerializeField]

        public AudioClip ActionSFX {  get; private set; }

        public AudioClip DropSFX { get; private set; }


        public bool PerformAction(GameObject character, List<ItemParameter> itemState)
        {
            AgentParent weapon = character.GetComponentInChildren<AgentParent>();
            if(weapon != null)
            {
                weapon.SetWeapon(this,itemState==null?DefautParameters:itemState);
                return true;

            }
            return false;
        }
    }
}