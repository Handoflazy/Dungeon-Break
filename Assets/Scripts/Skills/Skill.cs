using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour { }
public interface IMoveSkill { }
public interface IFirstSkill { }
public interface ISecondSkill { }

//public class DashSkill : AbstractSkill, IMoveSkill
//{
//    [SerializeField]
//    protected float dashTime = 0.1f;

//    [SerializeField]
//    protected float dashingPower = 5;

//    private Rigidbody2D rb;
//    protected bool isDashing = false;

//    protected override void Awake()
//    {
//        base.Awake();
//        rb = GetComponent<Rigidbody2D>();
//        cooldown = 2;
//    }
//    public override void OnUsed()
//    {

//        StartCoroutine(Dash());

//    }
//    private IEnumerator Dash()
//    {
//        isDashing = true;
//        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
//        Vector2 direction = GetPointerPos() - (Vector2)transform.position;
//        rb.velocity = direction.normalized * dashingPower;
//        yield return new WaitForSeconds(dashTime);
//        isDashing = false;
//        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
//    }

//}


//public class EnhanceSkill : AbstractSkill, ISecondSkill
//{
//    [SerializeField]
//    private float enhanceTime = 5f;
//    public int speedFactor;

//    private Animator anim = null;
//    private GameObject enhanceVFX = null;

//    private bool isCasting = false;

//    private GunWeapon gunWeapon;

//    private void Start()
//    {
//        gunWeapon = GetComponentInChildren<GunWeapon>();
//        enhanceVFX = Instantiate(Resources.Load("Shield_2_Ref", typeof(GameObject))) as GameObject;
//        enhanceVFX.gameObject.transform.SetParent(transform, false);
//        anim = enhanceVFX.GetComponent<Animator>();
//        enhanceVFX.SetActive(false);
//    }

//    protected override void Awake()
//    {
//        base.Awake();
//        cooldown = 10;
//    }
//    private void LateUpdate()
//    {
//        if (enhanceVFX != null)
//        {
//            enhanceVFX.transform.position = transform.position;
//        }
//    }

//    private int EnhanceActive = Animator.StringToHash("Shield_2_active");
//    private void SetActiveAnim()
//    {
//        enhanceVFX.SetActive(true);
//        anim.Play(EnhanceActive);
//    }


//    public override void OnUsed()
//    {
//        if (!isCasting)
//        {
//            StartCoroutine(Enhance()); //loi kich hoat de nhieu lan;
//        }
//    }

//    private IEnumerator Enhance()
//    {
//        speedFactor = gunWeapon.speedFactor;
//        SetActiveAnim();

//        isCasting = true;
//        gunWeapon.speedFactor = speedFactor * 2;

//        yield return new WaitForSeconds(0.7f);
//        enhanceVFX.SetActive(false);

//        yield return new WaitForSeconds(enhanceTime - 0.7f);
//        gunWeapon.speedFactor = speedFactor;
//        isCasting = false;
//    }
//}

//public class Grenade : AbstractSkill, IFirstSkill
//{
//    [SerializeField]
//    private float waitTime = 2f;

//    [SerializeField]
//    private int explosionPower = 5;

//    [SerializeField]
//    private float knockback = 1f;

//    [SerializeField]
//    private float explosionRadius = 0.16f;

//    private Rigidbody2D rb;

//    private List<GameObject> grenades = new List<GameObject>();
//    private Animator anim = null;
//    private GameObject explosionVFX = null;

//    private Animator animC4 = null;


//    private AudioSource audioSource = null;
//    [SerializeField]
//    private AudioClip explosionVFXClip = null;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        explosionVFX = Instantiate(Resources.Load("explosion", typeof(GameObject))) as GameObject;
//        explosionVFX.SetActive(false);
//        anim = explosionVFX.GetComponent<Animator>();
//    }


//    private void Update()
//    {
//        if (explosionVFX == null)
//        {
//            explosionVFX = Instantiate(Resources.Load("explosion", typeof(GameObject))) as GameObject;
//            anim = explosionVFX.GetComponent<Animator>();
//            explosionVFX.SetActive(false);
//        }
//    }

//    private int ExplosionActive = Animator.StringToHash("explosion_active");
//    private void SetActiveAnim(GameObject grenadeObject)
//    {
//        explosionVFX.SetActive(true);
//        explosionVFX.transform.position = grenadeObject.transform.position;
//        anim.Play(ExplosionActive);
//    }

//    protected override void Awake()
//    {
//        base.Awake();
//        cooldown = 3;
//    }

//    public override void OnUsed()
//    {
//        StartCoroutine(ThrowGrenade());
//    }

//    private int C4Active = Animator.StringToHash("c4_active");
//    protected IEnumerator ThrowGrenade()
//    {
//        GameObject grenadeObject = Instantiate(Resources.Load("grenade", typeof(GameObject))) as GameObject;
//        grenadeObject.transform.position = transform.position;
//        audioSource = grenadeObject.GetComponent<AudioSource>();
//        grenades.Add(grenadeObject);

//        onActive = true;

//        animC4 = grenadeObject.GetComponent<Animator>();
//        animC4.Play(C4Active);

//        yield return new WaitForSeconds(waitTime);

//        onActive = false;

//        StartCoroutine(Explosion(grenadeObject));
//    }

//    protected IEnumerator Explosion(GameObject grenadeObject)
//    {
//        Destroy(grenadeObject);
//        grenades.Remove(grenadeObject);
//        PlayExplosionAudio();
//        SetActiveAnim(grenadeObject);
//        explosionVFX.GetComponent<DamageSource>().OnHitEnemy += OnTriggerEnemy;
//        yield return new WaitForSeconds(0.5f);

//        explosionVFX.SetActive(false);
//    }

//    protected void PlayExplosionAudio()
//    {
//        audioSource.volume = 1;
//        audioSource.clip = explosionVFXClip;
//        audioSource.Play();
//    }

//    protected void OnTriggerEnemy(GameObject target)
//    {
//        int i = 0;
//        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionVFX.transform.position, explosionRadius);

//        foreach (Collider2D collider in colliders)
//        {
//            GameObject enemy = collider.gameObject;

//            if (enemy.TryGetComponent<Damageable>(out Damageable D))
//            {
//                print(i + ": " + enemy.name);
//                D.DealDamage(explosionPower, gameObject);
//                i++;
//            }

//            if (target.TryGetComponent<Rigidbody2D>(out Rigidbody2D enemyRb))
//            {
//                Vector2 knockbackDirection = enemyRb.transform.position - explosionVFX.transform.position;
//                knockbackDirection = knockbackDirection.normalized;

//                enemyRb.AddForce(knockbackDirection * knockback, ForceMode2D.Impulse);
//            }
//        }

//        explosionVFX.GetComponent<DamageSource>().OnHitEnemy -= OnTriggerEnemy;
//    }
//}





