using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


[CreateAssetMenu(menuName = "Item/Bullet")]
public class BulletItemSO : ItemSO, IDestroyableItem, IItemAction
{
    public string ActionName => "Reload";

    [field: SerializeField]
    public BulletDataSO BulletData { get; private set; }
    [field: SerializeField]
    public AudioClip ActionSFX { get; private set; }
     [field: SerializeField]
    public AudioClip DropSFX { get; private set; }

    public bool PerformAction(GameObject character, List<ItemParameter> itemState)
    {
        WeaponParent weaponParent = character.GetComponentInChildren<WeaponParent>();
        if (weaponParent != null)
        {
            BulletDataSO bullet = weaponParent.GetCurrentUsingBullet();

            if (bullet == BulletData)
            {
                BasicGun Gun = weaponParent.CurrentGun;
                if (Gun.AmmoFull||Gun.IsReloading)
                    return false;
                Gun.FullReload();
                return true;
            }

        }
        return false;
    }
}
