using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.UI;
using Inventory.Model;
using System.Text;

namespace Inventory
{
    public class InventoryController : PlayerSystem
    {
        [SerializeField]
        private UIInventoryPage inventoryUI;
        [SerializeField]
        private InventorySO inventoryData;
        [SerializeField]
        private AudioClip dropClip;
        [SerializeField]
        private AudioSource audioSource;
        public List<InventoryItem> inventoryItems = new List<InventoryItem> ();
        private void OnEnable()
        {
            player.ID.playerEvents.OnInventoryToggle += OnInventoryToggle;
        }
        private void Start()
        {
            PrepareUIInventory();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach(InventoryItem item in inventoryItems)
            {
                if(item.IsEmpty) continue;
                inventoryData.AddItem(item);
            }
  
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach(var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
            }
  
        }

        private void PrepareUIInventory()
        {
            inventoryUI.InitiallizeInventoryUI(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnSwapitems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
           
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if(inventoryItem.IsEmpty) return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);

        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty) return;
            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                inventoryUI.ShowItemAction(itemIndex);
                inventoryUI.AddAction(itemAction.ActionName, () => PerformAction(itemIndex));
               
            }
            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryUI.ShowItemAction(itemIndex);
                inventoryUI.AddAction("Drop", () =>DropItem(itemIndex,inventoryItem.quantity));
            }
        }
        private void DropItem(int itemIndex, int quanity)
        {
            inventoryData.RemoveItem(itemIndex, quanity);
            audioSource.PlayOneShot(dropClip);
        }
        public void PerformAction(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty) return;
            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryData.RemoveItem(itemIndex, 1);
                inventoryUI.ResetSelection();
            }
            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject, inventoryItem.itemState);
                audioSource.PlayOneShot(itemAction.ActionSFX);
                if (inventoryData.GetItemAt(itemIndex).IsEmpty)
                    inventoryUI.ResetSelection();
                
            }
        }
        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            
            inventoryData.SwapItems(itemIndex_1, itemIndex_2);

        }
        //?
        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                inventoryUI.ResetSelection();
                return;
            }
            ItemSO item = inventoryItem.item;
            string description =PrepareDescription(inventoryItem);
            inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, description);
        }
        private string PrepareDescription(InventoryItem inventoryItem)
        {
            StringBuilder sb = new StringBuilder();
            for(int i =0;i<inventoryItem.itemState.Count;i++)
            {
                if (inventoryItem.itemState[i].isHidden)
                    continue;
                sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName}: " + $"{inventoryItem.itemState[i].value}"+ '\n');
                //sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName}" + $"{inventoryItem.itemState[i].value}/"
                //    + $"{inventoryItem.item.DefautParameters[i].value}+ \n");
            }
            sb.AppendLine();
            sb.Append(inventoryItem.item.Description);
            return sb.ToString();
        }
       

        private void OnInventoryToggle()
        {

            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                }
            }
            else
            {
               inventoryUI.Hide();

            }
          
        }
    }
}