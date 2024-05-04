using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer spriteCharacter;
    public Animator animatorCharactor;
    private int selectedOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        
    }
    void UpdateCharacter(int selectOption)
    {
        Character character = characterDB.GetCharacter(selectOption);
        spriteCharacter.sprite = character.characterSprite;
        //animatorCharactor.GetComponent<Animator>().runtimeAnimatorController = character.characterAnimator;
        //nameText.text = character.characterName;
        animatorCharactor.runtimeAnimatorController = character.characterAnimator;
    }
    void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    
}
