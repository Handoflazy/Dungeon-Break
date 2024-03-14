using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public static GameManager instance;
    //Resource
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    public FloatingTextManager floatingTextManager;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        floatingTextManager = GameObject.Find("Floating Text").GetComponent<FloatingTextManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        instance = this;
        PlayerPrefs.DeleteKey("SaveState");
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
       

    }
    //logic
    public PlayerController player;
   
    public int pesos;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize, color, position, motion, duration);  
    }
    
    //Save state
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState", s);
    }
    //Load State

    public void LoadState(Scene s, LoadSceneMode mode) {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //change the weapon level



    }
}
