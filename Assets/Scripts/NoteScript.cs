using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    [SerializeField]
    private string noteLine;
    [SerializeField]
    private float delayTime;
    private float lastTime=0;
    [SerializeField]
    private float waitTime = 0;
    private void Start()
    {
        lastTime = -10;
    }
    public void Show()
    {
        if (Time.time - lastTime > delayTime)
        {
            lastTime= Time.time;
            NguyenSingleton.Instance.FloatingTextManager.Show(noteLine, 25, Color.white, transform.position, Vector2.up, waitTime);
        }
    }
}
