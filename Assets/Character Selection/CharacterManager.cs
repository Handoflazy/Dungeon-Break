using UnityEditor.Animations;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public AnimatorController controllerCharacter;
    private int selectedOption =0;
    public Image image;

    [SerializeField]
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
       
    }
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
    private void Update()
    {
        image.sprite = spriteRenderer.sprite;
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
        //spriteCharacter.sprite = character.characterSprite;
        controllerCharacter = character.characterAnimator;
        nameText.text = character.characterName;
        image.sprite = character.characterSprite;
        animator.runtimeAnimatorController = controllerCharacter;
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
