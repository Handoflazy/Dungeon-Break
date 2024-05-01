using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }
    public void RenderBehindHead(bool val)
    {
      
        if (val)
        {
            weaponRenderer.sortingOrder = playerSortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerSortingOrder + 1;
        }
      
    }
}
