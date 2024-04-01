using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public ContactFilter2D contactFilter;
    private BoxCollider2D boxCollider;
    public Collider2D[] hits = new Collider2D[20];
    public int damagePoint = 1;
    public float pushForce = 1;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public  virtual void CompleteSwing()
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            else
            {
                if ((hits[i].gameObject.CompareTag("Fighter")))
                {
                    if ((hits[i].name != "Player"))
                    {
                        print("deal dame");
                        Damage dmg = new() { damageAmount = damagePoint, origin = transform.position, pushForce = pushForce };
                        hits[i].SendMessage("ReceivedDamage", dmg);
                        hits[i] = null;
                       
                    }
                }
            }

        }
        
    }
    IEnumerator RevertColor(SpriteRenderer render)
    {
        yield return new WaitForSeconds(0.2f);

        render.color = Color.white;
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
                if ((hits[i].gameObject.CompareTag("Fighter")))
                {
                    if ((hits[i].name != "Player"))
                    {
                        OnCollide(hits[i]);
                       
                    }
                }
            }

        }

    }
    protected virtual void OnCollide(Collider2D other)
    {
        SpriteRenderer Render = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Render.color = Color.red;
        StartCoroutine(RevertColor(Render));
    }
   

}
