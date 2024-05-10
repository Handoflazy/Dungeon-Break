using Inventory.Model;
using Shooter;
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
    private GameObject droppedWeaponPrefab, droppedResoucePrefabs;
    
    [SerializeField]
    private float dropForce;

    public void DropLoot()
    {

       InstantiateLoot(transform.position);
    }
    public void DropLoots()
    {
        InstantiateLoots(transform.position);
    }
    List<Loot> GetDroppedItems()
    {
        Random.InitState((int)Time.time);
        int randomNumber = Random.Range(1, 101);
        print(randomNumber);
        List<Loot> possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
             
            }
        }
        return possibleItems;
    }
    Loot GetDroppedItem()
    {
        Random.InitState((int)Time.time);
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (item.dropChance>=randomNumber)
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
        Loot loot = GetDroppedItem();

        if (loot != null)
        {
            if (loot.ItemPrefab.GetComponent<DropWeapon>())
            {
                SpawnGun(loot.ItemPrefab);
            }
            if (loot.ItemPrefab.GetComponent<Resource>())
            {
                SpawnResource(loot.ItemPrefab);
            }
        }
    }
    public void InstantiateLoots(Vector3 spawnPosition)
    {
        List<Loot> droppedItems = GetDroppedItems();
        if (droppedItems==null)
            return;
        foreach (var loot in droppedItems)
        {
            if (loot.ItemPrefab.GetComponent<BasicGun>())
            {

               SpawnGun(loot.ItemPrefab);
            }
            if (loot.ItemPrefab.GetComponent<Resource>())
            {
               SpawnResource(loot.ItemPrefab);
            }
           
        }
    }
    
    private void SpawnResource(GameObject resource)
    {
        Vector3 offset = Random.insideUnitCircle * .08f;
        Instantiate(resource, transform.position + offset, Quaternion.identity);
        DropFeedback(resource);
    }

    private void SpawnGun(GameObject gunToSpawn)
    {
        Vector3 offset = Random.insideUnitCircle * .08f;
        GameObject droppedGun = droppedWeaponPrefab;
        droppedGun.GetComponent<DropWeapon>().GunPrefab = gunToSpawn;
        droppedGun.GetComponent<DropWeapon>().BulletNumber = Random.Range(1, gunToSpawn.GetComponent<BasicGun>().Ammo);
        droppedGun = Instantiate(droppedGun, transform.position+offset, Quaternion.identity);
        DropFeedback(droppedGun);

    }

    private void DropFeedback(GameObject Drop)
    {
        Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if (Drop.GetComponent<Rigidbody2D>())
            Drop.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
    }
}
[Serializable]
public class Loot
{
    public GameObject ItemPrefab;
    [Range(0,100)]
    public float dropChance;
}
