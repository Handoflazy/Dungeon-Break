using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float delay = 1.0f;
    float delta = 0;

    Player2 player;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Color color;
    public Material material=null;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delta > 0) { delta -= Time.deltaTime; }
        else { delta = delay; createGhost(); }
    }

    private void createGhost()
    {
        GameObject ghostObj = Instantiate(ghostPrefab, transform.position, transform.rotation);
        ghostObj.transform.localScale = player.transform.localScale;
        // Quay hình của ghostObj để phản ánh hướng di chuyển của player
        

        //ghostObj.transform.localScale = player.transform.localScale;
        Destroy(ghostObj, destroyTime);
   
        spriteRenderer = ghostObj.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player.spriteRenderer.sprite;
        spriteRenderer.color = color;
        if(material != null) spriteRenderer.material = material;

        spriteRenderer.sortingOrder = 5;
        /* if (player.transform.rotation.y == -180) // Nếu player quay về phải
         {
             ghostObj.transform.rotation = Quaternion.Euler(0, 0, 0);
         }
         else // Nếu player quay về trái
         {
             ghostObj.transform.rotation = Quaternion.Euler(0, -180, 0);
         }*/
        spriteRenderer.flipX = true;
    }
}
