using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponInfor weaponInfo;

    public WeaponInfor GetWeaponInfo()
    {
        return weaponInfo;
    }
}
