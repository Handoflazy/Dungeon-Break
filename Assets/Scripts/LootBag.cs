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
    private GameObject droppedWeaponPrefab;
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
        Vector3 offset = Random.insideUnitCircle * .08f;

        if (loot != null)
        {
            GameObject lootGameObject = null;
            if (loot.ItemPrefab.GetComponent<Shooter.DropWeapon>())
            {
                lootGameObject = Instantiate(GunToSpawn(loot.ItemPrefab), transform.position + offset, Quaternion.identity);
            }
            if (loot.ItemPrefab.GetComponent<Resource>())
            {
                lootGameObject = Instantiate(loot.ItemPrefab, transform.position + offset, Quaternion.identity);
            }
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            if (lootGameObject.GetComponent<Rigidbody2D>())
                lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
    public void InstantiateLoots(Vector3 spawnPosition)
    {
        List<Loot> droppedItems = GetDroppedItems();
        if (droppedItems==null)
            return;
        foreach (var loot in droppedItems)
        {
            Vector3 offset = Random.insideUnitCircle * .08f;
            GameObject lootGameObject = null;
            if (loot.ItemPrefab.GetComponent<BasicGun>())
            {

                lootGameObject = GunToSpawn(loot.ItemPrefab);
                print(lootGameObject.name);
            }
            if (loot.ItemPrefab.GetComponent<Resource>())
            {
                print(1);
                lootGameObject = Instantiate(loot.ItemPrefab,transform.position+offset,Quaternion.identity);
            }
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            if(lootGameObject.GetComponent<Rigidbody2D>())
                lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection*dropForce,ForceMode2D.Impulse);
        }
    }
    

    private GameObject GunToSpawn(GameObject gunToSpawn)
    {
        GameObject droppedGun = Instantiate(droppedWeaponPrefab, transform.position, Quaternion.identity);
        droppedGun.GetComponent<DropWeapon>().Gun.WeaponPrefab = gunToSpawn;
        droppedGun.GetComponent<DropWeapon>().BulletNumber = Random.Range(1, gunToSpawn.GetComponent<BasicGun>().Ammo);
        return droppedGun;


    }
}
[Serializable]
public class Loot
{
    public GameObject ItemPrefab;
    [Range(0,100)]
    public float dropChance;
}
