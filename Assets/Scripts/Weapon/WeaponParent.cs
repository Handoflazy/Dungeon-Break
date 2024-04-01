using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 Pointerposition { get; set; }
    public GameObject slashAnimPrefab;
    public SlashAnim slashAnim;
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
    
    public bool IsAttacking { get; set; }
    

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (Pointerposition - (Vector2)transform.position).normalized;
        Vector2 scale = transform.localScale;

        if (direction.y < 0.64 && direction.y > -0.9)
        {

            if (direction.x < 0)
                scale.y = -1;
            else if (direction.x > 0) scale.y = 1;
            transform.right = direction;
            transform.localScale = scale;
        }

        if (transform.up.y < 0 && transform.up.y >= -1)
        {

            weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        }
    }
 
    public void ResetIsAttacking()
    {
        IsAttacking = false;
        anim.SetBool("SecondAttack", false);
    }
    GameObject slashAnimationObject;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
      
        slashAnimationObject = Instantiate(slashAnimPrefab, transform);
        slashAnimationObject.name = "SlashAnimation";
        transform.parent = transform;
        slashAnim = GameObject.Find("SlashAnimation").GetComponent<SlashAnim>();
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelayTime);
        attackBlocked = false;
    }
    public void SwingUpFipAnim()
    {
        slashAnimationObject.transform.localScale = new Vector3(1, -1, 1);
    }
    public void Attack()
    {
        if (!anim)
        {
            return;
        } 
        if (attackBlocked)
            return;   
        IsAttacking = true;
        attackBlocked = true;
        anim.SetTrigger("Attack");
        StartCoroutine(AttackDelay());
    }
    public void ActivateSlashAnim()
    {
        slashAnim.ActivateEffect();
    }
    public void DeactiveSlashAnim()
    {
        slashAnim.DeactivateEffect();
    }
}

