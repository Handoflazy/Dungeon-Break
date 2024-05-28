using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBoss : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Image image;
    public Transform panel;
    public Transform panel2;
    public float scaleSpeed = 1.0f;
    public float cd;
    public float timeCD = 0.75f;

    public void Update()
    {
        cd += Time.deltaTime;
        image.sprite = spriteRenderer.sprite;
        if(cd >= timeCD)
        {
            Vector3 currentScale = panel.transform.localScale;
            currentScale.y -= scaleSpeed * Time.deltaTime;
            panel.transform.localScale = currentScale;
            panel2.transform.localScale = currentScale;
        }
        
    }

}
