using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            
            
          
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
       
    }
}
