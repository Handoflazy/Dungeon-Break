using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    private Transform weaponCollider;
    public int damagePoint = 0;
    public float pushForce = 0;
    [SerializeField]
    Animator anim;
    [SerializeField]
    private LayerMask layerMask;
    public GameObject slashAnimPrefab;
    public SlashAnim slashAnim;
    GameObject slashAnimationObject;
    private bool onLeftSide = false;

    public void OnChangeSideEvent(bool onRightSide)
    {
        this.onLeftSide = onRightSide;
    }


    private void Awake()
    {
        _weaponType = WeaponType.Melee;
        anim = GetComponent<Animator>();

        CreateSlashObject();
       
    }

    private void CreateSlashObject()
    {
        slashAnimationObject = Instantiate(slashAnimPrefab, transform.parent);
        slashAnimationObject.name = "SlashAnimation";
        slashAnim = GameObject.Find("SlashAnimation").GetComponent<SlashAnim>();
    }

    public  virtual void CompleteSwingEvent()
    {
        weaponCollider.gameObject.SetActive(false);

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
    public override void OnUse()
    {
        anim.SetTrigger("Attack");
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
        weaponCollider.gameObject.SetActive(true);
    }
    public void DeactivateWeaponCollider()
    {
        weaponCollider.gameObject.SetActive(false);
    }

}
