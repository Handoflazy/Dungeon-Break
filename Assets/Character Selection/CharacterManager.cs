using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer spriteCharacter;
    public AnimatorController controllerCharacter;
    private int selectedOption =0;

    private void Start()
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

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount) 
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption <0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    void UpdateCharacter(int selectOption)
    {
        Character character = characterDB.GetCharacter(selectOption);
        spriteCharacter.sprite = character.characterSprite;
        controllerCharacter = character.characterAnimator;
        nameText.text = character.characterName;
    }
    void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    
}
