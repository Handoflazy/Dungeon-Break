using GreenLeaf;
using PlayerController;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Load : MonoBehaviour
{
    //public Save_Load Save_Load;
    public PlayerStatsSO PlayerStatsSO;
    //public PlayerHealth PlayerHealth;
    //public Transform playerTransform;
    public int baseHP = 200;
    public int baseLUXR = 10;
    private void Start()
    {
        
    }

    public void LoadGame()
    {
        //AdvancedPlayerPrefs.GetTransform("playerTransform", Save_Load.playerTransform);

    }
    public void NewGame()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("p_z");
        PlayerPrefs.DeleteKey("currentHealth");

        PlayerStatsSO.level = 1;
        PlayerStatsSO.xp = 0;
        PlayerStatsSO.hp = baseHP;
        PlayerStatsSO.levelUpXpRequire = baseLUXR;
        //PlayerHealth.MaxHealth = 200;
        //PlayerHealth.CurrentHealth = 200;
    }
    public void ChangeScene(string str)
    {
        SceneManager.LoadScene(str);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
