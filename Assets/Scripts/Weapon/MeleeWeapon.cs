using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public ContactFilter2D contactFilter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Update()
    {
        boxCollider.OverlapCollider(contactFilter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            else
            {
                OnCollide(hits[i]);
                hits[i] = null;
            }

        }
    }
    protected virtual void OnCollide(Collider2D other)
    {
        Debug.Log("Collide not detect on " + other.name);
    }
   

}
