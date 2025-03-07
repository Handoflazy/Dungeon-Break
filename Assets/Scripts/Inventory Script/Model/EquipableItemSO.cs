using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Item/Equipment")]
    public class EquipableItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        [field: SerializeField]
        public GameObject WeaponPrefap { get; private set; }
        [field: SerializeField]
        public BulletItemSO BulletItemSO { get; private set; }

        


        [field: SerializeField]

        public AudioClip ActionSFX {  get; private set; }

        public AudioClip DropSFX { get; private set; }


        public bool PerformAction(GameObject character, List<ItemParameter> itemState)
        {
            WeaponParent weapon = character.GetComponentInChildren<WeaponParent>();
            if(weapon != null)
            {
                weapon.SetWeapon(this, 0);
                return true;

            }
            return false;
        }
    }
}