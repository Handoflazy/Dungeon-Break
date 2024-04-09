using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerID playerID;
    private void GameOver()
    {
       Time.timeScale = 0;
    }
    private void Awake()
    {

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
        
       

    }


    public void RestartGame()
    {
        
    }





    //Load State
    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //player.transform.position = GameObject.Find("SpawnPos").transform.position;
    }
    public void LoadState(Scene s, LoadSceneMode mode) {
        SceneManager.sceneLoaded -= LoadState;
       


    }
    public void Respawn()
    {
        print("restart");
        SceneManager.LoadScene("Floor1");
        playerID.playerEvents.onRespawn?.Invoke();
        // player.Respawn();

    }
    public Vector3 GenerateSpawnPos(float x, float y)
    {
        return new Vector3(Random.Range(-x,x),Random.Range(-y,y),0);
    }
}
