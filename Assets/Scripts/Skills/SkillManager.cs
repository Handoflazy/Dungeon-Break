using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(Duration))]
public class SkillManager : PlayerSystem
{
    private Duration duration;

    public WeaponType WeaponType;
        
    public IMoveSkill iMoveSkill;
    public AbtractSkill moveSkill;
    private bool isMoveSkillCooldown;
    private bool isAttackSkillCooldown;
    private bool isDefendSkillCooldown;

    protected override void Awake()
    {
        base.Awake();
        duration = GetComponent<Duration>();
    }
    private void OnEnable()
    {
        player.ID.playerEvents.OnMoveSkillUsed += OnSpaceDown;
        player.ID.playerEvents.OnWeaponChage += OnWeaponChangeEvent;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMoveSkillUsed -= OnSpaceDown;
        player.ID.playerEvents.OnWeaponChage -= OnWeaponChangeEvent;
    }
    private void HandleWeaponType()
    {
        Component c = gameObject.GetComponent<IMoveSkill>() as Component;

        if (c != null)
        {
            Destroy(c);
        }

        switch(WeaponType)
        {
            case WeaponType.Melee:
                moveSkill = gameObject.AddComponent<DashSkill>();
                break;
            case WeaponType.Range:
                moveSkill = gameObject.AddComponent<LeapSkill>();
                break;
            case WeaponType.Staff:
                moveSkill = gameObject.AddComponent<TeleportSkill>();
                break;
            default:
                moveSkill = gameObject.AddComponent<DashSkill>();
                break;
        }


    }
    public void OnSpaceDown()
    {
        int durationCost = moveSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isMoveSkillCooldown)
        {
            moveSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartMoveSkillCooldown(moveSkill.GetCowndown()));
        }
    }

    IEnumerator StartMoveSkillCooldown(float timeCD)
    {
        isMoveSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isMoveSkillCooldown = false;

    }

    private void Start()
    {
        HandleWeaponType();
        isMoveSkillCooldown = false;
    }

    public void OnWeaponChangeEvent()
    {
        HandleWeaponType();
        print("onweaponChange ");
    }
}


