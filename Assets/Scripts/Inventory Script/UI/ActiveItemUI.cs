using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItemUI : MonoBehaviour
{
    [SerializeField] Image nonItemImage, ItemImage;

    public void ResetSlot()
    {
        nonItemImage.enabled = true;
        ItemImage.enabled = false;
    }
    public void SetItemImage(Sprite image)
    {
        nonItemImage.enabled = false;
        ItemImage.enabled= true;
        ItemImage.sprite = image;
    }
  
}
