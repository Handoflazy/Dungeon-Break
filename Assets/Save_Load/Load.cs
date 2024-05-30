using Inventory.Model;
using PlayerController;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class Load : MonoBehaviour
{
    //public Save_Load Save_Load;
    public PlayerStatsSO PlayerStatsSO;
    public EnemyStatsSO enemyMeleeStatSO;
    public EnemyStatsSO enemyRangerStatSO;
    public InventorySO inventorySO;
    //public PlayerHealth PlayerHealth;
    //public Transform playerTransform;
    public int baseHP = 200;
    public int baseLUXR = 10;
    public int baseDuration = 100;
    public int baseHpMelee = 70;
    public int baseHpRanger = 35;
    public int basedmgMelee = 5;
    public int basedmgRanger = 10;
    public int baseMinXp = 10;
    public int baseMaxXp = 50;
    private void Start()
    {
        
    }

    public void LoadGame()
    {

    }
    public void NewGame()
    {
        inventorySO.ResetInventoryData();
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("p_z");
        PlayerPrefs.DeleteKey("currentHealth_data");
        PlayerPrefs.DeleteKey("currentGun");
        PlayerPrefs.DeleteKey("currentBulletCount");
        PlayerPrefs.DeleteKey("MedikitCount_data");
        PlayerPrefs.DeleteKey("AmmoBoxCount_data");
        PlayerPrefs.DeleteKey("currentDuration_data");


        PlayerStatsSO.level = 1;
        PlayerStatsSO.duration = baseDuration;
        PlayerStatsSO.hp = baseHP;
        PlayerStatsSO.levelUpXpRequire = baseLUXR;
        PlayerStatsSO.xp = 0;

        enemyMeleeStatSO.hp = baseHpMelee;
        enemyMeleeStatSO.damage = basedmgMelee;
        enemyMeleeStatSO.minXpBonus = baseMinXp;
        enemyMeleeStatSO.maxXpBonus = baseMaxXp;
        enemyRangerStatSO.hp = baseHpRanger;
        enemyRangerStatSO.damage = basedmgRanger;
        enemyRangerStatSO.minXpBonus = baseMinXp;
        enemyRangerStatSO.maxXpBonus = baseMaxXp;




    }
    public void ChangeScene(string str)
    {
        // lam truoc cai LoadScene chu chua co SaveScene do chua co 2 map
        if (PlayerPrefs.HasKey("currentScene"))
        {
            string currentScene = PlayerPrefs.GetString("currentScene");
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            SceneManager.LoadScene(str);
        }
        
    }
    public void ChangeSceneNewGame(string str)
    {
        // lam truoc cai LoadScene chu chua co SaveScene do chua co 2 map
        if (PlayerPrefs.HasKey("currentScene"))
        {
            string currentScene = PlayerPrefs.GetString("currentScene");
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            SceneManager.LoadScene(str);
        }

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
