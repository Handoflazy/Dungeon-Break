using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSkill : MonoBehaviour
{
    public Image image;
    public Sprite icon_1;
    public Sprite icon_2;
    //public List<Image> icon;
    //private void Start()
    private void Update()
    {
        if(PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1)
        {
            image.sprite = icon_1;
        }
        else
        {
            image.sprite = icon_2;
        }
    }
}
