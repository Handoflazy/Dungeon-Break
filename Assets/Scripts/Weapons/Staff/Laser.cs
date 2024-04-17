using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float LaserRanger;
    private float LaserWidth;
    [SerializeField] private float laserGrowTime =2f;

    private bool isGrowing = true;

    private CapsuleCollider2D capsuleCollider;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void OnEnable()
    {
        isGrowing = true;
    }
    private IEnumerator IncreaseLaserLenghRoutine()
    {
        float timePassed = 0f;
        while(spriteRenderer.size.x < LaserRanger)
        {
            timePassed += Time.deltaTime;
            float linerT = timePassed / laserGrowTime;

            spriteRenderer.size = new Vector2(Mathf.Lerp(0.15f,LaserRanger, linerT), LaserWidth);
            capsuleCollider.size = new Vector2(spriteRenderer.size.x,spriteRenderer.size.y/2);

            capsuleCollider.offset = new Vector2(Mathf.Lerp(0.15f, LaserRanger, linerT)/2, capsuleCollider.offset.y);
            yield return null;
        }
        StartCoroutine(GetComponent<SpriteFade>().SlowFadeRoutine());
    }
     public void UpdateLaserRange(float laserRange, float laserWidth)
    {
        this.LaserRanger = laserRange;
        this.LaserWidth = laserWidth;
        StartCoroutine(IncreaseLaserLenghRoutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}

