using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour{}
public interface IMoveSkill{}
public interface IFirstSkill{}
public interface ISecondSkill { }

public class DashSkill : AbstractSkill, IMoveSkill
{
    [SerializeField]
    private float dashTime = 0.1f;

    [SerializeField]
    private float dashingPower = 5;

    private Rigidbody2D rb;
    private bool isDashing = false;

    [SerializeField]
    private TrailRenderer trailRenderer;

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
    private Animator anim;
    private Animator anim_2;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        //trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        //trailRenderer.startColor = Color.blue;
        //anim = GetComponentInChildren<Animator>();
        //anim_2 = GetComponent<SkillManager>().CurrentWeapon.gameObject.GetComponent<Animator>();
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
        //trailRenderer.emitting = true;

        //anim_2.SetTrigger("Fire");
        //GameObject arrow = Instantiate(Resources.Load("arrow", typeof(GameObject))) as GameObject;
        //CommonArrow arrowSetting = arrow.GetComponent<CommonArrow>();
        //arrowSetting.Distance = distance;
        //arrow.transform.position = transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, 90);

        yield return new WaitForSeconds(dashTime);
        //trailRenderer.emitting = false;
        isBackSteping = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isBackSteping);
    }
}

public class TeleportSkill : AbstractSkill, ISecondSkill
{
    [SerializeField]
    private float teleportTime = 0.5f;

    [SerializeField]
    private float teleportDistance = 0.5f;

    private bool isTeleporting = false;
    private Animator anim;
    GameObject teleportVFX;

    private void Start()
    {
        teleportVFX = Instantiate(Resources.Load("Teleport_Ref", typeof(GameObject))) as GameObject;
        teleportVFX.gameObject.transform.SetParent(transform, false);
        //teleportVFX.transform.localPosition = new Vector3(0,0.05f,0);
        anim = teleportVFX.GetComponent<Animator>();
        teleportVFX.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnUsed()
    {
        if (!isTeleporting)
        {
            StartCoroutine(Teleport());
        }
    }

    private int TeleportFlash = Animator.StringToHash("Teleport_active");
    private void SetActiveAnim()
    {
        teleportVFX.SetActive(true);
        anim.Play(TeleportFlash);

    }

    private IEnumerator Teleport()
    {
        isTeleporting = true;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isTeleporting);
        SetActiveAnim();


        Vector2 teleportPosition = GetTeleportPosition();
        player.transform.position = teleportPosition;

        yield return new WaitForSeconds(teleportTime);

        isTeleporting = false;
        teleportVFX.SetActive(false);
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isTeleporting);
    }

    private Vector2 GetTeleportPosition()
    {
        Vector2 direction = GetPointerPos() - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, teleportDistance, LayerMask.GetMask("Blocking"));

        if (hit.collider != null)
        {
            // Nếu có va chạm với chướng ngại vật
            Vector2 obstaclePosition = hit.point - (Vector2)transform.position;
            Vector2 teleportPos = (Vector2)transform.position + obstaclePosition.normalized * (obstaclePosition.magnitude - 0.1f);
            return teleportPos;
        }
        else
        {
            // Nếu không có va chạm với chướng ngại vật
            Vector2 teleportPos = (Vector2)transform.position + direction.normalized * teleportDistance;
            return teleportPos;
        }
    }
}
