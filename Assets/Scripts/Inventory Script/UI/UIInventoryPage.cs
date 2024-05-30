using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] UIInventoryItem inventoryItemUIPrefab;

        [SerializeField] Transform contentPanel;

        [SerializeField]
        private UIInventoryDescription UIDescription;

        [SerializeField]
        private MouseFollower mouseFollower;



        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnDescriptionRequested,
            OnItemActionRequested, OnStartDragging;

        public event Action<int, int> OnSwapitems;
        [SerializeField]
        private ItemActionPanel actionPanel;

        private void Awake()
        {
            UIDescription.ResetDescription();
           //ide();
        }

        public void InitiallizeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                UIInventoryItem uiItem = Instantiate(inventoryItemUIPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem);

                uiItem.OnItemClicked += HandledItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }
        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        private void HandleSwap(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1||currentlyDraggedItemIndex==-1)
            {
                return;
            }
           
            OnSwapitems?.Invoke(currentlyDraggedItemIndex, index);
            HandledItemSelection(inventoryItemUI);

            //UIDescription.ResetDescription();
        }

        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        private void HandleEndDrag(UIInventoryItem inventoryItemUI)
        {
            ResetDraggedItem();
        }

        private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            HandledItemSelection(inventoryItemUI);
            OnItemActionRequested?.Invoke(index);
        }

        private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;

            currentlyDraggedItemIndex = index;
            HandledItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);


        }
        public void CreateDraggedItem(Sprite spite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(spite, quantity);
        }
        private void HandledItemSelection(UIInventoryItem inventoryItemUI)
        {

            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);


        }

        public void Show()
        {
            gameObject.SetActive(true);
            UIDescription.ResetDescription();
            mouseFollower.Toggle(false);
            ResetSelection();
        }

        public void ResetSelection()
        {
            UIDescription.ResetDescription();
            DeselectAllItems();
        }
        public void AddAction(string actionName,Action performAction)
        {
            actionPanel.AddButton(actionName, performAction);
        }
        public void ShowItemAction(int itemIndex)
        {
            actionPanel.Toggle(true);
            actionPanel.transform.position = listOfUIItems[itemIndex].transform.position;

        }
        private void DeselectAllItems()
        {
            foreach (UIInventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
            actionPanel.Toggle(false);
        }

        public void Hide()
        {

            actionPanel.Toggle(false);
            gameObject.SetActive(false);
            ResetDraggedItem();
        
        }

        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            UIDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            listOfUIItems[itemIndex].Select();
        }

        public void ResetAllItems()
        {
            foreach(var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }
    }
}