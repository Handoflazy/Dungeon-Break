using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguyenSingleton : MonoBehaviour
{
    public static NguyenSingleton Instance { get; private set; }
    public GameObject inputPlayer;
    public GameObject HUB;
    public GameObject mainCamera;
    public GameObject astarPathfinder;
    //public GameObject AudioManager;
    public FloatingTextManager FloatingTextManager { get; private set; }
    public GameManager GameManager { get; private set; }
    public SceneManagement SceneManagement { get; private set; }

    public ActiveInventoryUI ActiveInventory { get; private set; }    

    public UIFade UIfade { get; private set; }

    public UIInventoryPage UIInventoryPage { get; private set; }
    public AudioManager AudioManager { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        { 
            Instance = this;
            FloatingTextManager = GetComponentInChildren<FloatingTextManager>();
            GameManager = GetComponentInChildren<GameManager>();
            SceneManagement = GetComponentInChildren<SceneManagement>();
            UIfade = GetComponentInChildren<UIFade>();
            ActiveInventory = GetComponentInChildren<ActiveInventoryUI>();
            DontDestroyOnLoad(gameObject);
            UIInventoryPage = GetComponentInChildren<UIInventoryPage>();
            AudioManager = GetComponentInChildren<AudioManager>();
        }
        
    }
    
}
