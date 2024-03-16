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
        //PlayerPrefs.DeleteKey("SaveState");
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
       

    }
    //logic
    public PlayerController player;
    public Weapon weapon;
    public int pesos;
    public int experience;
    public int level;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize, color, position, motion, duration);  
    }
    public bool TryUpdateWeapon()
    {
        if (weapon.weaponLevel >= weaponSprites.Count)
        {

            return false;
        }
        if (pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
            
        
    }
    public int GetExperience()
    {
        return experience;
    }
    public int GetTotalExpToNextLvl()
    {
        return xpTable[level];
    }
    public void GrandXp(int xp)
    {
        experience += xp;
    }
    public void LevelUp()
    {
        if(level==xpTable.Count)
        {
            return;
        }
        experience -= xpTable[level];
        level++;
        player.OnLevelUp();
    }
    //Save state
    public void SaveState()
    {
        
        string s = "";
        s += level + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += playerSprites.FindIndex(n=>n==player.GetSprite()) + "|";
        s += weapon.weaponLevel;
        PlayerPrefs.SetString("SaveState", s);
    }
    //Load State

    public void LoadState(Scene s, LoadSceneMode mode) {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //change player skin
        level = int.Parse(data[0]);
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        player.SetRender(int.Parse(data[3]));
        weapon.SetLevelWeapon(int.Parse(data[4]));
        //change the weapon level



    }
    
    public Vector3 GenerateSpawnPos(float x, float y)
    {
        return new Vector3(Random.Range(-x,x),Random.Range(-y,y),0);
    }
}
