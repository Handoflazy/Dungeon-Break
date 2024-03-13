using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 10;
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Debug.Log("Grand 5 peso");
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
       
    }
}
