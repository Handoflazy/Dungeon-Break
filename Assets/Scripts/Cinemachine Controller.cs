using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CinemaChineController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera defaultCamera;
   
    [SerializeField]
    PlayerID playerID;
   

    [SerializeField]
    private CinemachineVirtualCamera ZoomCamera;

    private void OnEnable()
    {
        playerID.playerEvents.OnZoomCamera += OnZoomEvent;
    }
    private void OnDisable()
    {
        playerID.playerEvents.OnZoomCamera -= OnZoomEvent;
    }
    private void Start()
    {
        SetPlayerCameraFollow();
    }
    public void SetPlayerCameraFollow()
    {
        Transform playerTransform = GameObject.Find("Player").transform;
        defaultCamera.Follow = playerTransform;
        ZoomCamera.Follow = playerTransform;
    }

    private void OnZoomEvent()
    {

        if (ZoomCamera.Priority < defaultCamera.Priority)
        {
            
            ZoomCamera.Priority = defaultCamera.Priority + 1;
        }
        else
        {
            ZoomCamera.Priority = defaultCamera.Priority - 1;
        }
    }
    
}
