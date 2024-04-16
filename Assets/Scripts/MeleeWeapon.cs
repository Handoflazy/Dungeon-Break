using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    private LayerMask layerMask;
    public GameObject slashAnimPrefab;  
    public SlashAnim slashAnim;
    GameObject slashAnimationObject;
    private bool onLeftSide = false;

    public WeaponParent weaponParent;

    public void OnChangeSideEvent(bool onRightSide)
    {
        this.onLeftSide = onRightSide;
    }

    private void OnEnable()
    {
        AnimatedCharacter.Instance.OnLeftSide += OnChangeSideEvent;
    }
    private void OnDisable()
    {
        AnimatedCharacter.Instance.OnLeftSide -= OnChangeSideEvent;
    }
    private void Start()
    {
        WeaponType = WeaponType.Melee;
        WeaponAnim = GetComponent<Animator>();
        weaponParent = transform.parent.GetComponent<WeaponParent>();
        //CreateSlashObject();
    }

    private void CreateSlashObject()
    {
        slashAnimationObject = Instantiate(slashAnimPrefab, transform.parent);
        slashAnimationObject.name = "SlashAnimation";
        slashAnim = GameObject.Find("SlashAnimation").GetComponent<SlashAnim>();
    }

    public  virtual void CompleteSwingEvent()
    {
        weaponParent.ResetIsAttacking();

    }
    IEnumerator RevertColor(SpriteRenderer render)
    {
        yield return new WaitForSeconds(0.2f);
        render.color = Color.white;
    }
    public void SwingUpFipAnimEvent()
    {
        SpriteRenderer temp = slashAnim.GetComponent<SpriteRenderer>();
        slashAnimationObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        if (onLeftSide)
        {
            temp.flipX = true;
        }
        else
        {
            temp.flipX = false;
        }

    }
    public override void Attack()
    {
        WeaponAnim.SetTrigger("Attack");
    }
    public void SwingDownFipAnimEvent()
    {
        SpriteRenderer temp = slashAnim.GetComponent<SpriteRenderer>();
        slashAnimationObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (onLeftSide)
        {
            temp.flipX = true;
        }
        else
        {
            temp.flipX = false;
        }

    }
    protected virtual void OnCollide(Collider2D other)
    {
        SpriteRenderer Render = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Render.color = Color.red;
        StartCoroutine(RevertColor(Render));
    }

    public void ActivateSlashAnim()
    {
        slashAnim.ActivateEffect();
    }
    public void DeactiveSlashAnim()
    {
        slashAnim.DeactivateEffect();
    }
    public void ActivateWeaponCollider()
    {
        weaponParent.MeleeWeaponCollider.gameObject.SetActive(true);
    }
    public void DeactivateWeaponCollider()
    {
        weaponParent.MeleeWeaponCollider.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        Destroy(slashAnimationObject);
    }
}
