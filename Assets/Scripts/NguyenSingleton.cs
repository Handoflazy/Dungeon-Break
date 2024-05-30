using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguyenSingleton : MonoBehaviour
{
    public static NguyenSingleton Instance { get; private set; }

    public FloatingTextManager FloatingTextManager { get; private set; }
    public GameManager GameManager { get; private set; }
    public SceneManagement SceneManagement { get; private set; }

    public ActiveInventoryUI ActiveInventory { get; private set; }    

    public UIFade UIfade { get; private set; }

    public UIInventoryPage UIInventoryPage { get; private set; }
    public AudioController AudioManager { get; private set; }


    public DialogueController DialogueController { get; private set; }
    public HUBController HUBController { get; private set; }

    public MenuController MenuController { get; private set; }

    public BossHealthBArController BossHealthBArController { get; private set; }
    [field: SerializeField]
    public PlayerID PlayerID { get; internal set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            if (PlayerID == null)
            {
                PlayerID = new PlayerID();
            }
            Instance = this;
            DialogueController = GetComponentInChildren<DialogueController>();
            FloatingTextManager = GetComponentInChildren<FloatingTextManager>();
            GameManager = GetComponentInChildren<GameManager>();
            SceneManagement = GetComponentInChildren<SceneManagement>();
            UIfade = GetComponentInChildren<UIFade>();
            ActiveInventory = GetComponentInChildren<ActiveInventoryUI>();
            //DontDestroyOnLoad(gameObject);
            UIInventoryPage = GetComponentInChildren<UIInventoryPage>();
            AudioManager = GetComponentInChildren<AudioController>();
            HUBController = GetComponentInChildren<HUBController>();
            MenuController = GetComponentInChildren<MenuController>();
            BossHealthBArController = GetComponentInChildren<BossHealthBArController>();
        }
        
    }
    
}
