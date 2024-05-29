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
    //public PlayerHealth PlayerHealth;
    //public Transform playerTransform;
    public int baseHP = 200;
    public int baseLUXR = 10;
    public int baseDuration = 100;
    private void Start()
    {
        
    }

    public void LoadGame()
    {

    }
    public void NewGame()
    {
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
