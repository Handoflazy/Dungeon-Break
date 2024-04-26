using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.TimeZoneInfo;

public class FirstSkillManager : MonoBehaviour
{
}

public interface IFirstSkill { }

public class Wideslash : AbstractSkill, IFirstSkill
{
    [SerializeField] 
    private Animator Anim;


    private void Start()
    {
       // Anim = GetComponent<SkillManager>().currentWeapon.gameObject.GetComponent<Animator>();
    }

    private readonly int wideSlash = Animator.StringToHash("WideSlash");
  

    public override void OnUsed()
    {
       
            Anim.Play(wideSlash);
            print(1);
        
    }
}

public class FireballSkill : AbstractSkill, IFirstSkill
{
    [SerializeField]
    private float[] fireballCoolDown = { .2f, .2f, .3f, .5f };

    [SerializeField]
    private float[] fireballDistance = { .5f, .5f, 1, 1, 1.5f };

    private bool isCasting = false;
    private Animator anim;
    GameObject fireballVFX;

    private void Start()
    {
        fireballVFX = Instantiate(Resources.Load("Fireball_Ref", typeof(GameObject))) as GameObject;
        fireballVFX.gameObject.transform.SetParent(player.transform, false);
        anim = fireballVFX.GetComponent<Animator>();
        fireballVFX.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        fireballVFX.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void LateUpdate()
    {
        if (fireballVFX != null)
        {
            fireballVFX.transform.position = transform.position;
        }
        else
        {
            fireballVFX = Instantiate(Resources.Load("Fireball_Ref", typeof(GameObject))) as GameObject;
            fireballVFX.gameObject.transform.SetParent(player.transform, false);
            anim = fireballVFX.GetComponent<Animator>();
            fireballVFX.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            fireballVFX.SetActive(false);
        }
    }

    public override void OnUsed()
    {
        if (!isCasting)
        {
            StartCoroutine(Fireball());
        }
    }

    private readonly int FireballActive = Animator.StringToHash("Fireball_active_form2");
    private void SetActiveAnim()
    {
        fireballVFX.transform.position = player.transform.position;
        fireballVFX.SetActive(true);
        anim.Play(FireballActive);
    }


    private IEnumerator Fireball()
    {
        isCasting = true;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isCasting);
        SetActiveAnim();

        //set hieu ung cast chieu
        yield return new WaitForSeconds(0.5f);

        GameObject newFireball = Instantiate(Resources.Load("Fireball_Ref", typeof(GameObject))) as GameObject;
        newFireball.transform.position = transform.position;
        Vector2 direction = GetPointerPos() - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        SpriteRenderer fireballSpriteRenderer = newFireball.GetComponent<SpriteRenderer>();
        fireballSpriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D fireballRigidbody = newFireball.GetComponent<Rigidbody2D>();
        fireballRigidbody.AddForce(direction.normalized * 5f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(fireballCoolDown[level] - 0.5f);

        isCasting = false;
        fireballVFX.SetActive(false);
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isCasting);
    }

    private bool CheckObstacleCollision()
    {
        Vector2 direction = GetPointerPos() - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, fireballDistance[level], LayerMask.GetMask("Blocking"));

        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}

