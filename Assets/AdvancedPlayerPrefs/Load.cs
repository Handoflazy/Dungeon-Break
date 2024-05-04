using GreenLeaf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Load : MonoBehaviour
{
    public Save_Load Save_Load;
    //public Transform playerTransform;
    private void Start()
    {
        //Transform save_Load = GetComponent<Save_Load>;

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
        PlayerPrefs.DeleteKey("hp");
        PlayerPrefs.DeleteKey("xp");
        PlayerPrefs.DeleteKey("lv");
        /*if (!PlayerPrefs.HasKey("lv")) { level = 1; level++; };
        if (!PlayerPrefs.HasKey("xp")) { xp = 0; };
        if (!PlayerPrefs.HasKey("hp")) { hp = 500; };*/
    }
 
}
