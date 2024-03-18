using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //textField
    public TextMeshProUGUI levelText, hitPointText, pesosText, upgradeCodeText, xpText;

    //login
    private int currentCharacterSeletion = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;
    
    private void Start()
    {   
        currentCharacterSeletion = GameManager.instance.playerSprites.FindIndex(n => n == GameManager.instance.player.GetSprite());
    }
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSeletion++;
            if(currentCharacterSeletion > GameManager.instance.playerSprites.Count)
            {
                currentCharacterSeletion = 0;   
            }
        }
        else
        {
            currentCharacterSeletion--;
            if(currentCharacterSeletion < 0)
            {
                currentCharacterSeletion = GameManager.instance.playerSprites.Count - 1;
            }
        }
        OnSelectionChanged();
        
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSeletion];
        GameManager.instance.player.SetRender(currentCharacterSeletion);
        UpdateMenu();
    }

    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpdateWeapon())
        {
            UpdateMenu();
        }
    }
    public void UpdateMenu()
    {
        //Weapon
        characterSelectionSprite.sprite = GameManager.instance.player.GetSprite();
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponSprites.Count-1)
        {
            upgradeCodeText.text ="MAX";
        }
        else
        {
           
            upgradeCodeText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();
            

        }

        //META
        levelText.text = GameManager.instance.level.ToString();
        hitPointText.text = GameManager.instance.player.hitPoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();
        int Exp = GameManager.instance.experience;
        int ExpToNext = GameManager.instance.xpTable[GameManager.instance.level];
        xpText.text = Exp.ToString() + "/" +ExpToNext.ToString();

        xpBar.localScale = new Vector3((float)Exp / ExpToNext, 1, 1);
    }
   
}
