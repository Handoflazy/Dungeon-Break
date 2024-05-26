using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField]
    private EquippabeItemSO weapon;

    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private List<ItemParameter> parametersToModify, itemCurrentState;

     public void SetWeapon(EquippabeItemSO weaponItemS0, List<ItemParameter> itemState)
    {
        if(weapon !=null)
        {
            inventoryData.AddItem(weapon,1, itemCurrentState);
        }
        this.weapon = weaponItemS0;
        itemCurrentState = new List<ItemParameter>(itemState);
        ModifyParameters();
        
    }

    private void ModifyParameters()
    {
       foreach(var parameter in parametersToModify)
        {
            if (itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }
}
