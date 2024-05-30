using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.UI;
using Inventory.Model;
using System.Text;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Inventory
{
    public class InventoryController : PlayerSystem
    {
        [SerializeField]
        private UIInventoryPage inventoryUI;
        [SerializeField]
        private InventorySO inventoryData;
        [SerializeField] GameObject dropItemPrefab;


        [SerializeField]
        private AudioClip dropClip;
        [SerializeField]
        private AudioSource audioSource;
        private void OnEnable()
        {
            player.ID.playerEvents.OnInventoryToggle += OnInventoryToggle;
            player.ID.playerEvents.OnDropItem += DropItem;
            PrepareUIInventory();
            PrepareInventoryData();
        }

        private void OnDisable()
        {
            player.ID.playerEvents.OnInventoryToggle -= OnInventoryToggle;
            player.ID.playerEvents.OnDropItem -= DropItem;
            inventoryData.OnInventoryUpdated -= UpdateInventoryUI;
        }

        private void Start()
        {
            if (inventoryUI.isActiveAndEnabled)
            {
                OnInventoryToggle();
            }
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
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
            if (inventoryItem.IsEmpty) return;
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
                inventoryUI.AddAction("Drop", () => DropItem(itemIndex, inventoryItem.quantity));
            }
        }
        private void DropItem(int itemIndex, int quanity)
        {
            Item item = dropItemPrefab.GetComponent<Item>();
            item.InventoryItem = inventoryData.GetItemAt((int)itemIndex).item;
            item.Quantity = quanity;
            SpawnItem(dropItemPrefab);
            inventoryData.RemoveItem(itemIndex, quanity);
            audioSource.clip = dropClip;
            audioSource.Play();
            inventoryUI.ResetSelection();
        }

        private void DropItem(ItemSO dropItem, int quantity)
        {
            Item item = dropItemPrefab.GetComponent<Item>();
            item.InventoryItem = dropItem;
            item.Quantity = quantity;
         
            SpawnItem(dropItemPrefab);


        }

        private void SpawnItem(GameObject itemToSpawn)
        {
            Vector3 offset = Random.insideUnitCircle * .16f;
            Item item = Instantiate(itemToSpawn, transform.position + Vector3.one*0.08f + offset, Quaternion.identity).GetComponent<Item>();
            // DropFeedback(droppedGun);
            item.DelayPick();

        }
        public void PerformAction(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty) return;
            IItemAction itemAction = inventoryItem.item as IItemAction;
            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
        
            if (itemAction != null)
            {
                if (itemAction.PerformAction(gameObject, inventoryItem.itemState))
                {
                    audioSource.PlayOneShot(itemAction.ActionSFX);
                    if (destroyableItem != null)
                    {
                        inventoryData.RemoveItem(itemIndex, 1);
                        inventoryUI.ResetSelection();
                    }
                }
                if (inventoryData.GetItemAt(itemIndex).IsEmpty)
                {
                    inventoryUI.ResetSelection();
                }

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
            string description = PrepareDescription(inventoryItem);
            inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, description);
        }
        private string PrepareDescription(InventoryItem inventoryItem)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inventoryItem.itemState.Count; i++)
            {
                if (inventoryItem.itemState[i].isHidden)
                    continue;
                sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName}: " + $"{inventoryItem.itemState[i].value}" + '\n');
                //sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName}" + $"{inventoryItem.itemState[i].value}/"
                //    + $"{inventoryItem.item.DefautParameters[i].value}+ \n");
            }
            sb.AppendLine();
            sb.Append(inventoryItem.item.Description);
            return sb.ToString();
        }


        private void OnInventoryToggle()
        {
            if (inventoryUI == null)
            {
                return;
            }
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