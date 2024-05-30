using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;
using PlayerController;

public class PickUpSystem : PlayerSystem
{
    [SerializeField]
    private InventorySO inventoryData = null;
    private ItemManager itemsManager=null;
    private BasicGun Gun = null;
    private void Start()
    {
        itemsManager = GetComponent<ItemManager>();
        
    }
    private void OnEnable()
    {
        player.ID.playerEvents.OnChangeGun += OnChangeGun;
    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnChangeGun -= OnChangeGun;
    }
    private void OnChangeGun(BasicGun gun)
    {
        Gun = gun;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            if (reminder == 0)
            {
                item.DestroyItem();
            }
            else
                item.Quantity = reminder;
        }
    }
   

        
}
