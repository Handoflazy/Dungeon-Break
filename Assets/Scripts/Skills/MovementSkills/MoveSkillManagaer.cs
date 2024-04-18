using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MoveManager : MonoBehaviour
{
}
public interface IMoveSkill
{
}

public class DashSkill : AbstractSkill, IMoveSkill
{
    [SerializeField]
    private float[] dashTime = { .1f, .2f, .3f, .5f };

    [SerializeField]
    private float[] dashingPower = { 4, 5, 6, 7, 8 };

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
        trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        trailRenderer.startColor = Color.red;

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
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
    }

}
public class LeapSkill : AbstractSkill, IMoveSkill
{
    [SerializeField]
    private float[] dashTime = { .2f, .2f, .3f, .5f };

    [SerializeField]
    private float[] dashingPower = { 4, 5, 6, 7, 8 };

    private Rigidbody2D rb;
    private bool isDashing = false;

    [SerializeField]
    private TrailRenderer trailRenderer;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        trailRenderer.startColor = Color.blue;
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
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);

    }
}


public class TeleportSkill : AbstractSkill, IMoveSkill
{
    [SerializeField]
    private float[] dashTime = { .2f, .2f, .3f, .5f };

    [SerializeField]
    private float[] dashingPower = { 4, 5, 6, 7, 8 };

    private Rigidbody2D rb;
    private bool isDashing = false;

    [SerializeField]
    private TrailRenderer trailRenderer;







    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        trailRenderer.startColor = Color.green;
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
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);

    }
   

}