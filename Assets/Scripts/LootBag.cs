using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootBag : MonoBehaviour
{
    [SerializeField]
    private List<Loot> lootList;
    [SerializeField]
    private GameObject droppedItemPrefab;
    [SerializeField]
    private float dropForce;

    public void DropLoot()
    {

        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }

    List<Loot> GetDroppedItems()
    {
        int randomNumber =Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                return possibleItems;
            }
        }
        return null;
    }
    Loot GetDroppedItem()
    {
        Random.InitState((int)Time.time);
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No root dropped");
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        
        if (droppedItem != null)
        {
            droppedItemPrefab.GetComponent<Item>().InventoryItem = droppedItem.Item;
            GameObject lootGameObject = Instantiate(droppedItemPrefab,spawnPosition,Quaternion.identity);
            Vector2 dropDirection = new Vector2( Random.Range(-1f,1f),Random.Range(-1f,1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection*dropForce,ForceMode2D.Impulse);
        }
    }

}
[Serializable]
public class Loot
{
    public ItemSO Item;
    public float dropChance;
}
