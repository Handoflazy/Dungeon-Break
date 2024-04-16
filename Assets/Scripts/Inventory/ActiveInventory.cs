using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    [SerializeField]
    PlayerReform player;
    private int activeSlotIndexNum = 0;
    [SerializeField]
    private WeaponParent activeWeapon;

    public event Action<Weapon> OnWeaponChanged;

    private void OnEnable()
    {
        player.ID.playerEvents.OnToggleActiveSlot += ToggleActiveSlot;
    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnToggleActiveSlot -= ToggleActiveSlot;
    }
    private void Start()
    {
        activeWeapon = player.GetComponentInChildren<WeaponParent>();
        ToggleActiveHighlight(1);
    }
    private void ToggleActiveSlot(int slotIndex)
    {
        ToggleActiveHighlight(slotIndex - 1);
    }
    private void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;
        foreach(Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(activeSlotIndexNum ).GetChild(0).gameObject.SetActive(true);
        ChangeActiveWeapon();

    }
    private void ChangeActiveWeapon()
    {
        if (!transform.GetChild(activeSlotIndexNum).GetComponent<InventorySlot>().GetWeaponInfo())
        {
            player.ID.playerEvents.OnChangeWeapon?.Invoke(null);
            return;
        }

        GameObject WeaponToSpawn = transform.GetChild(activeSlotIndexNum).GetComponent<InventorySlot>().GetWeaponInfo().weaponPrefab;
        //GameObject newWeapon = Instantiate(WeaponToSpawn, activeWeapon.gameObject.transform.position, Quaternion.identity);
        GameObject newWeapon = Instantiate(WeaponToSpawn, activeWeapon.transform);
        //newWeapon.transform.parent = activeWeapon.transform;
        OnWeaponChanged?.Invoke(newWeapon.GetComponent<Weapon>());
        player.ID.playerEvents.OnChangeWeapon?.Invoke(newWeapon.GetComponent<Weapon>());
        newWeapon.transform.localRotation = WeaponToSpawn.transform.rotation;
        
    }



}
