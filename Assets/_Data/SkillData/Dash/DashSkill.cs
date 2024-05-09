using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashSkill : AbstractSkill
{
    [SerializeField]
    protected AudioClip activeSkill;

    [SerializeField]
    protected float dashTime = 0.2f;

    [SerializeField]
    protected float dashingPower = 5;

    [SerializeField]
    protected TrailRenderer trailRenderer;

    private Rigidbody2D rbPlayer;

    private AudioSource audioSource;

    protected bool isDashing = false;

    protected override void Awake()
    {
        base.Awake();
        rbPlayer = GetComponent<Rigidbody2D>();
        cooldown = 2;
        audioSource = GetComponent<AudioSource>();
    }
    public override void OnUsed()
    {
        audioSource.PlayOneShot(activeSkill);

        StartCoroutine(Dash());
        
    }
    private IEnumerator Dash()
    {
        trailRenderer.enabled = true;
        isDashing = true;
        base.player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);

        Vector2 direction = GetPointerPos() - (Vector2)transform.position;
        rbPlayer.velocity = direction.normalized * dashingPower;

        yield return new WaitForSeconds(dashTime);

        trailRenderer.enabled = false;
        isDashing = false;
        base.player.ID.playerEvents.OnMoveSkillUsing?.Invoke(isDashing);
        
    }

}
