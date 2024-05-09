using GreenLeaf;
using PlayerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class Save_Load : MonoBehaviour
{
    public PlayerStatsSO PlayerStatsSO;
    public PlayerHealth playerHealth;
    public Transform playerTransform;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        //PlayerStatsSO = new PlayerStatsSO();
        float pX = playerTransform.position.x;
        float pY = playerTransform.position.y;
        float pZ = playerTransform.position.z;
        pX = PlayerPrefs.GetFloat("p_x");
        pY = PlayerPrefs.GetFloat("p_y");
        pZ = PlayerPrefs.GetFloat("p_z");
        playerTransform.transform.position = new Vector3(pX, pY, pZ);
        sceneName = PlayerPrefs.GetString("saveScene");
        //SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;*/
        PlayerPosSave();
    }
    public void PlayerPosSave()
    {
        /*AdvancedPlayerPrefs.SetInt("hP", hp);
        AdvancedPlayerPrefs.SetInt("duration", duration);
        AdvancedPlayerPrefs.SetInt("damage", damage);
        AdvancedPlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        AdvancedPlayerPrefs.SetFloat("knockForce", knockForce);
        AdvancedPlayerPrefs.SetInt("lv", level);
        AdvancedPlayerPrefs.SetInt("xp", xp);*/
        PlayerPrefs.SetFloat("p_x", playerTransform.transform.position.x);
        PlayerPrefs.SetFloat("p_y", playerTransform.transform.position.y);
        PlayerPrefs.SetFloat("p_z", playerTransform.transform.position.z);
        //PlayerPrefs.SetString("saveScene", sceneName);
        PlayerPrefs.Save();
    }
    /*public void Load()
    {
        *//*AdvancedPlayerPrefs.GetInt("hP", hp);
        AdvancedPlayerPrefs.GetInt("duration", duration);
        AdvancedPlayerPrefs.GetInt("damage", damage);
        AdvancedPlayerPrefs.GetFloat("moveSpeed", moveSpeed);
        AdvancedPlayerPrefs.GetFloat("knockForce", knockForce);
        AdvancedPlayerPrefs.GetInt("lv", level);
        AdvancedPlayerPrefs.GetInt("xp", xp);*//*
        AdvancedPlayerPrefs.GetTransform("transformPlayer", playerTransform);
        Transform transform = playerTransform;
    }*/

}
