using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveManager : MonoBehaviour
{
}
public interface IMoveSkill
{
}

public class DashSkill : AbtractSkill, IMoveSkill
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

    private void OnEnable()
    {
        player.ID.playerEvents.OnMousePointer += GetPointerPos;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMousePointer -= GetPointerPos;
    }
    private void GetPointerPos(Vector2 pointerPos)
    {
        mousePos = pointerPos;
    }
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
        Vector2 direction = mousePos - (Vector2)transform.position;
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
    }

}
public class LeapSkill : AbtractSkill, IMoveSkill
{
    [SerializeField]
    private float[] dashTime = { .2f, .2f, .3f, .5f };

    [SerializeField]
    private float[] dashingPower = { 4, 5, 6, 7, 8 };

    private Rigidbody2D rb;
    private bool isDashing = false;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private Vector2 mousePos;

    private void OnEnable()
    {
        player.ID.playerEvents.OnMousePointer += GetPointerPos;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMousePointer -= GetPointerPos;
    }
    private void GetPointerPos(Vector2 pointerPos)
    {
        mousePos = pointerPos;
    }



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
        Vector2 direction = mousePos - (Vector2)transform.position;
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);

    }
}


public class TeleportSkill : AbtractSkill, IMoveSkill
{
    [SerializeField]
    private float[] dashTime = { .2f, .2f, .3f, .5f };

    [SerializeField]
    private float[] dashingPower = { 4, 5, 6, 7, 8 };

    private Rigidbody2D rb;
    private bool isDashing = false;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private Vector2 mousePos;

    private void OnEnable()
    {
        player.ID.playerEvents.OnMousePointer += GetPointerPos;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMousePointer -= GetPointerPos;
    }
    private void GetPointerPos(Vector2 pointerPos)
    {
        mousePos = pointerPos;
    }



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
        Vector2 direction = mousePos - (Vector2)transform.position;
        rb.velocity = direction.normalized * dashingPower[level];
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime[level]);
        trailRenderer.emitting = false;
        isDashing = false;
        player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);

    }
   

}