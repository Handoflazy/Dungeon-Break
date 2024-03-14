using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText 
{
    public bool active;
    public GameObject origin;
   
    public TextMeshProUGUI text;
    public Vector3 motion;
    public float duration;
    public float lastShow;

    public void Show()
    {
        active = true;
        lastShow = Time.time;
        origin.SetActive(active);
    }
    public void Hide() 
        {
            active = false;
            origin.SetActive(active);
        } 
    public void UpdateFloatingText()
    {
        if (!active) { return; };
        if(Time.time - lastShow>duration) {
            Hide();
        }
        origin.transform.position += motion * Time.deltaTime;

    }
    
}
