using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Item/Ammo")]
    public class AmmoItemSO : ItemSO, IItemAction, IDestroyableItem
    {
        public string ActionName => "Reload";
        [SerializeField]
        private int BulletReload;
        [field: SerializeField]
        public AudioClip ActionSFX { get; private set; }

        public AudioClip DropSFX { get; private set; }



        public bool PerformAction(GameObject character, List<ItemParameter> itemState)
        {
           BasicGun currentGun = character.GetComponentInChildren<BasicGun>();
            if (currentGun != null)
            {
                currentGun.Reload(BulletReload);
                return true;
            }
            return false;
        }

    }
}