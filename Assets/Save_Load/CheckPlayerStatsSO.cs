using PlayerController;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.VisualScripting;

//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class CheckPlayerStatsSO: MonoBehaviour
{
    public Image img_Continue;
    //public PlayerStatsSO PlayerStatsSO;

    private void Start()
    {
        CheckPlayerSO();
    }

    public void LoadGame()
    {

    }

    public void CheckPlayerSO()
    {
        int currentHP = PlayerPrefs.GetInt(PrefConsts.CURRENT_HEALTH_KEY);
        if (currentHP <= 0)
        {
            img_Continue.GetComponent<Button>().interactable = false;
            _=img_Continue.color.WithAlpha(240);
        }
        else
        {
            img_Continue.GetComponent<Button>().interactable = true;
            _=img_Continue.color.WithAlpha(255);
        }
    }
}
