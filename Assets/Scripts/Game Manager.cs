using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerID playerID;

    [SerializeField]
    private Texture2D cursorTexture = null;

    private void Start()
    {
        SetCursorIcon();
    }

    private void SetCursorIcon()
    {
        Cursor.SetCursor(cursorTexture,new Vector2(cursorTexture.width/2f,cursorTexture.height/2f),CursorMode.Auto);
    }

    private void GameOver()
    {
       Time.timeScale = 0;
    }
    private void Awake()
    {

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void ResetTimeScale()
    {
        if(this)
            StopAllCoroutines();
        Time.timeScale = 1;
    }
    public void  ModifyTimeScale(float endTimeValue, float timeToWait, Action OnCompleteCallBack=null)
    {
        StartCoroutine(TimeScaleCoroutine(endTimeValue, timeToWait, OnCompleteCallBack));

    }
    IEnumerator TimeScaleCoroutine(float endTimeValue, float timeToWait, Action OnCompleteCallBack)
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        Time.timeScale = endTimeValue;
        OnCompleteCallBack?.Invoke();
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
        playerID.playerEvents.onRespawn?.Invoke();
        SceneManager.LoadScene("Floor1");
        // player.Respawn();

    }
    public Vector3 GenerateSpawnPos(float x, float y)
    {
        return new Vector3(Random.Range(-x,x),Random.Range(-y,y),0);
    }
}
