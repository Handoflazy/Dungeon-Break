using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float LaserRanger;
    [SerializeField] private float laserGrowTime =2f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private IEnumerator IncreaseLaserLenghRoutine()
    {
        float timePassed = 0f;
        while(spriteRenderer.size.x < LaserRanger)
        {
            timePassed += Time.deltaTime;
            float linerT = timePassed / laserGrowTime;

            spriteRenderer.size = new Vector2(Mathf.Lerp(1,LaserRanger, linerT), 0.16f);
            yield return null;
        }
    }
     public void UpdateLaserRange(float laserRange)
    {
        this.LaserRanger = laserRange;
        StartCoroutine(IncreaseLaserLenghRoutine());
    }
    
       
}

