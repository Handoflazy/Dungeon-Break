using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour { }
public interface IMoveSkill { }
public interface IFirstSkill { }
public interface ISecondSkill { }

public class DashSkill : AbstractSkill, IMoveSkill
{
    [SerializeField]
    private float dashTime = 0.1f;

    [SerializeField]
    private float dashingPower = 5;

    private Rigidbody2D rb;
    private bool isDashing = false;

    //[SerializeField]
    //private TrailRenderer trailRenderer;

    private Vector2 mousePos;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        canUse = true;
        //trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        //trailRenderer.startColor = Color.red;

    }
    public override void OnUsed()
    {

        StartCoroutine(Dash());

    }
    private IEnumerator Dash()
    {
        isDashing = true;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
        Vector2 direction = GetPointerPos() - (Vector2)transform.position;
        rb.velocity = direction.normalized * dashingPower;
        //trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime);
        //trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
    }

}

public class BackStepSkill : AbstractSkill, IFirstSkill
{
    [SerializeField]
    private float dashTime = 0.1f;

    [SerializeField]
    private float dashingPower = 5;

    private Rigidbody2D rb;
    private bool isBackSteping = false;
    public float distance = 2f;
    [SerializeField]
    private TrailRenderer trailRenderer;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public override void OnUsed()
    {
        StartCoroutine(BackStep());
    }
    private IEnumerator BackStep()
    {

        isBackSteping = true;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isBackSteping);
        Vector2 direction = (Vector2)transform.position - GetPointerPos();
        rb.velocity = direction.normalized * dashingPower;
 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        yield return new WaitForSeconds(dashTime);
        isBackSteping = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isBackSteping);
    }
}

public class EnhanceSkill : AbstractSkill, ISecondSkill
{
    [SerializeField]
    private float enhanceTime = 5f;
    public int speedFactor;

    private Animator anim = null;
    private GameObject enhanceVFX = null;

    private bool isCasting = false;

    private GunWeapon gunWeapon;

    private void Start()
    {
        gunWeapon = GetComponentInChildren<GunWeapon>();
        enhanceVFX = Instantiate(Resources.Load("Shield_2_Ref", typeof(GameObject))) as GameObject;
        enhanceVFX.gameObject.transform.SetParent(transform, false);
        anim = enhanceVFX.GetComponent<Animator>();
        enhanceVFX.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
    }
    private void LateUpdate()
    {
        if (enhanceVFX != null)
        {
            enhanceVFX.transform.position = transform.position;
        }
    }

    private int EnhanceActive = Animator.StringToHash("Shield_2_active");
    private void SetActiveAnim()
    {
        enhanceVFX.SetActive(true);
        anim.Play(EnhanceActive);
    }


    public override void OnUsed()
    {
        StartCoroutine(Enhance()); //loi kich hoat de nhieu lan;
    }

    private IEnumerator Enhance()
    {
        speedFactor = gunWeapon.speedFactor;
        //int damage = player.playerStats.damage;
        //float speed = player.playerStats.moveSpeed;

        SetActiveAnim();

        isCasting = true;
        //player.playerStats.damage += damage;
        //player.playerStats.moveSpeed += speed;
        gunWeapon.speedFactor = speedFactor * 2;

        yield return new WaitForSeconds(0.7f);
        enhanceVFX.SetActive(false);

        yield return new WaitForSeconds(enhanceTime - 0.7f);

        //player.playerStats.damage -= damage;
        //player.playerStats.moveSpeed -= speed;
        gunWeapon.speedFactor = speedFactor;
        isCasting = false;
    }
}

public class Grenade : AbstractSkill, IFirstSkill
{
    [SerializeField]
    private float waitTime = 1f;

    [SerializeField]
    private int explosionPower = 5;

    [SerializeField]
    private float knockback = 1f;

    [SerializeField]
    private float explosionRadius = 0.16f;

    private Rigidbody2D rb;

    private List<GameObject> grenades = new List<GameObject>();
    private Animator anim = null;
    private GameObject explosionVFX = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionVFX = Instantiate(Resources.Load("explosion", typeof(GameObject))) as GameObject;
        explosionVFX.SetActive(false);
        anim = explosionVFX.GetComponent<Animator>();
    }

    private void Update()
    {
        if (explosionVFX == null)
        {
            explosionVFX = Instantiate(Resources.Load("explosion", typeof(GameObject))) as GameObject;
            anim = explosionVFX.GetComponent<Animator>();
            explosionVFX.SetActive(false);
        }
    }

    private int ExplosionActive = Animator.StringToHash("explosion_active");
    private void SetActiveAnim(GameObject grenadeObject)
    {
        explosionVFX.SetActive(true);
        explosionVFX.transform.position = grenadeObject.transform.position;
        anim.Play(ExplosionActive);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnUsed()
    {
        StartCoroutine(ThrowGrenade());
    }

    protected IEnumerator ThrowGrenade()
    {
        GameObject grenadeObject = Instantiate(Resources.Load("grenade", typeof(GameObject))) as GameObject;
        grenadeObject.transform.position = transform.position;
        grenades.Add(grenadeObject);

        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Explosion(grenadeObject));
    }

    protected IEnumerator Explosion(GameObject grenadeObject)
    {
        Destroy(grenadeObject);
        grenades.Remove(grenadeObject);
        SetActiveAnim(grenadeObject);
        explosionVFX.GetComponent<DamageSource>().OnHitEnemy += OnTriggerEnemy;
        yield return new WaitForSeconds(0.5f);
        
        explosionVFX.SetActive(false);
    }

    protected void OnTriggerEnemy(GameObject target)
    {
        int i = 0;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionVFX.transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            GameObject enemy = collider.gameObject;

            if (enemy.TryGetComponent<Damageable>(out Damageable D))
            {
                print(i + ": " + enemy.name);
                D.DealDamage(explosionPower, gameObject);
                i++;
            }

            if (target.TryGetComponent<Rigidbody2D>(out Rigidbody2D enemyRb))
            {
                Vector2 knockbackDirection = enemyRb.transform.position - explosionVFX.transform.position;
                knockbackDirection = knockbackDirection.normalized;

                enemyRb.AddForce(knockbackDirection * knockback, ForceMode2D.Impulse);
            }
        }

        explosionVFX.GetComponent<DamageSource>().OnHitEnemy -= OnTriggerEnemy;
    }
}





