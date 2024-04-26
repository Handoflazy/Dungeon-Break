using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.TimeZoneInfo;

public class SecondSkillManager : MonoBehaviour
{
}

public interface ISecondSkill
{
}

public class Giganize : AbstractSkill, ISecondSkill
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float[] GiganFactor = { .3f, .6f, .8f, .1f };
    private Vector3 localScale;
    [SerializeField]
    private float transitionTime = .4f;
    [SerializeField] float GiganTime = 2;
    [Range(0, 1), SerializeField] float t = .2f;

    private Color initialColor;
    [SerializeField] Color targetColor;
    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        localScale = transform.localScale;
        initialColor = spriteRenderer.color;

    }
    private void setUpLevel()
    {
        switch (level)
        {
            case 0: 
                targetColor = new Color32(0xFF, 0xD8, 0x00, 0xFF); 
                break;
            case 1: targetColor = new Color32(0xFF, 0x95, 0x00, 0xFF); 
                break;
            case 2: targetColor = new Color32(0xFF, 0x46, 0x00, 0xFF);
                break;
            case 3: targetColor = Color.red;
                break;
            case 4: targetColor = Color.green;
                break;
            default: break;


        }
    }
    private void Start()
    {
        setUpLevel();
    }
    public override void OnUsed()
    {

        StartCoroutine(Giganizing());

    }
    private IEnumerator Minimize()
    {

        Vector3 currentScale = transform.localScale;
        while (!Mathf.Approximately(currentScale.magnitude, localScale.magnitude))
        {
            StartCoroutine(TransitionColor(initialColor));
            currentScale = Vector3.Lerp(currentScale, localScale, t);
            transform.localScale = currentScale;
            yield return null;
        }
    }
    private IEnumerator Giganizing()
    {
        Vector3 currentScale = transform.localScale;
        Vector3 giganScale = currentScale * (1 + GiganFactor[level]);
        while (!Mathf.Approximately(currentScale.magnitude, giganScale.magnitude))
        {
            currentScale = Vector3.Lerp(currentScale, giganScale, t);
            StartCoroutine(TransitionColor(targetColor));
            transform.localScale = currentScale;
            yield return null;
        }
        yield return new WaitForSeconds(GiganTime);
        StartCoroutine(Minimize());
    }

    private IEnumerator TransitionColor(Color targetColor)
    {
        Color currentColor = spriteRenderer.color;
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            float t = elapsedTime / transitionTime;
            spriteRenderer.color = Color.Lerp(currentColor, targetColor, t);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    private void OnDestroy()
    {
        transform.localScale = localScale;
    }

}
public class ExplosionArrow : AbstractSkill, ISecondSkill
{

}
public class MagicShield : AbstractSkill, ISecondSkill
{
    //[SerializeField]
    //private float[] shieldCoolDown = { 5f, 3f, 3f, 2f };
    

    [SerializeField]
    private float[] shieldKnockback = { 1f, 1f, 2f, 2f, 3f };

    private bool isCasting = false;
    private Animator anim;
    GameObject shieldVFX;

    private void Start()
    {
        shieldVFX = Instantiate(Resources.Load("Shield_2_Ref", typeof(GameObject))) as GameObject;
        shieldVFX.gameObject.transform.SetParent(transform, false);
        anim = shieldVFX.GetComponent<Animator>();
        shieldVFX.SetActive(false);

        cooldown = new[]{ 5f, 3f, 3f, 2f, 2f};
    }

    protected override void Awake()
    {
        base.Awake();

    }

    public override void OnUsed()
    {
        if (!isCasting)
        {
            StartCoroutine(Shield());
        }
    }

    private void LateUpdate()
    {
        if (shieldVFX != null)
        {
            shieldVFX.transform.position = transform.position;
        }
    }

    private int ShieldActive = Animator.StringToHash("Shield_2_active");
    private void SetActiveAnim()
    {
        shieldVFX.SetActive(true);
        anim.Play(ShieldActive);
    }

    private IEnumerator Shield()
    {
        isCasting = true;
        //player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isCasting);
        SetActiveAnim();

        yield return new WaitForSeconds(0.7f);
        shieldVFX.SetActive(false);

        yield return new WaitForSeconds(cooldown[level] - 0.7f);
        isCasting = false;
        //player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isCasting);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Rigidbody2D enemyRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // Lấy hướng knockback
                Vector2 knockbackDirection = other.transform.position - transform.position;
                knockbackDirection = knockbackDirection.normalized;

                enemyRigidbody.AddForce(knockbackDirection * shieldKnockback[level], ForceMode2D.Impulse);
            }
        }
    }
}