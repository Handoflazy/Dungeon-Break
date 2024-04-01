using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 Pointerposition { get; set; }

    [SerializeField]
    private float SmoothAnim = 0.125f;

    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private SpriteRenderer weaponRenderer;
    [SerializeField]
    private bool attackBlocked;
    [SerializeField] 
    private float attackDelayTime;
    [SerializeField]
    private Animator anim;

    public bool IsAttacking { get; private set; }

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Vector2 direction = (Pointerposition - (Vector2)transform.position).normalized;
        Vector2 scale = transform.localScale;

        {
            // vu khi kiem thi dc xuay theo chuot
            //if (direction.y <0.7f)
            //{
            //transform.right = Vector3.Lerp(transform.right, direction, SmoothAnim);


            //}
            //if(transform.right.y < -0.2f) {
            //    weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
            //}
            //else
            //{
            //    weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
            //}

            //transform.localScale = scale;
        }
        if (direction.x < 0)
            scale.y = -1;
        else if (direction.x > 0) scale.y = 1;


    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelayTime);
        attackBlocked = false;
    }
    public void Attack()
    {
        if (attackBlocked)
            return;
        IsAttacking = true;
        attackBlocked = true;
        anim.SetTrigger("attack");
        StartCoroutine(AttackDelay());
    }
}
