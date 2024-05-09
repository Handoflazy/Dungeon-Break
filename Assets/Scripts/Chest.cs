using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    private bool collected = false;
    public UnityEvent OnOpenChest;
    public void OnOpen()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            OnOpenChest?.Invoke();

        }
       
    }
}
