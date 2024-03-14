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
            
            GameManager.instance.ShowText("+ " + pesosAmount + " pesos!",40,Color.yellow,transform.position,Vector3.up*50,3.0f);
            GameManager.instance.pesos += pesosAmount;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
       
    }
}
