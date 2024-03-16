using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Mover
{

    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public void SetRender(int id)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[id];
    }
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 input = new(horizontalInput, verticalInput, 0);
        UpdateMotor(input.normalized);
    }
    public void OnLevelUp(){
        maxHitPoint++;
        hitPoint = maxHitPoint;
        GameManager.instance.ShowText("Level Up!", 30, Color.green, transform.position, Vector3.up, 2.0f);
   }
  
}
