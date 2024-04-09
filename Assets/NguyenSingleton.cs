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
    public FloatingTextManager floatingTextManager { get; private set; }
    public GameManager gameManager { get; private set; }



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
            floatingTextManager = GetComponentInChildren<FloatingTextManager>();
            gameManager = GetComponentInChildren<GameManager>();
            DontDestroyOnLoad(gameObject);
        }
        
    }
    
}
