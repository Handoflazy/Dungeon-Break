using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
[RequireComponent(typeof(Duration))]
public class SkillManager : PlayerSystem
{
    public BoolEvent OnUsingMoveSkill;
    [field: SerializeField]
    public Weapon CurrentWeapon { get; set; }

    private Duration duration;

    public WeaponType weaponType;

    public IMoveSkill iMoveSkill;

    private AbstractSkill moveSkill;
    private AbstractSkill firstSkill;
    private AbstractSkill secondSkill;

    private bool isMoveSkillCooldown;
    private bool isFirstSkillCooldown;
    private bool isSecondSkillCooldown;



    protected override void Awake()
    {
        base.Awake();
        duration = GetComponent<Duration>();
    }
    private void OnEnable()
    {
        player.ID.playerEvents.OnMoveSkillUsed += OnMoveSkillUse;
        player.ID.playerEvents.OnLevelUp += OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing += UsingSkillTrigger;
        player.ID.playerEvents.OnSkillSecondUsed += OnSecondSkillUse;
        player.ID.playerEvents.OnSkillOneUsed += OnFirstSkillUse;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMoveSkillUsed -= OnMoveSkillUse;
        player.ID.playerEvents.OnLevelUp -= OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= UsingSkillTrigger;
        player.ID.playerEvents.OnSkillSecondUsed -= OnSecondSkillUse;
        player.ID.playerEvents.OnSkillSecondUsed -= OnFirstSkillUse;
    }

    void UsingSkillTrigger(bool isUsing)
    {
        OnUsingMoveSkill?.Invoke(isUsing);
    }

    private bool isMoveSkillAdded;
    private bool isFirstSkillAdded;
    private bool isSecondSkillAdded;

    private void HandleLevelUp()
    {
        int level = player.playerStats.level;
        print(level);

        if (level >= 5 && !isMoveSkillAdded)
        {
            moveSkill = gameObject.AddComponent<DashSkill>();
            isMoveSkillAdded = true;
        }

        if (level >= 10 && !isFirstSkillAdded)
        {
            firstSkill = gameObject.AddComponent<Grenade>();
            isFirstSkillAdded = true;
        }

        if (level >= 15 && !isSecondSkillAdded)
        {
            secondSkill = gameObject.AddComponent<EnhanceSkill>();
            isSecondSkillAdded = true;
        }
    }

    public void OnMoveSkillUse()
    {
        if (!moveSkill)
            return;
        int durationCost = moveSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isMoveSkillCooldown)
        {
            moveSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartMoveSkillCooldown(moveSkill.GetCowndown()));
        }
    }
    public void OnSecondSkillUse()
    {

        if (secondSkill == null)
            return;
        int durationCost = secondSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isSecondSkillCooldown)
        {
            secondSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
        }
    }
    public void OnFirstSkillUse()
    {

        if (firstSkill == null)
            return;
        int durationCost = firstSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isFirstSkillCooldown)
        {

            firstSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
        }
    }
    IEnumerator StartMoveSkillCooldown(float timeCD)
    {
        isMoveSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isMoveSkillCooldown = false;

    }
    IEnumerator StartFirstSkillCooldown(float timeCD)
    {
        isFirstSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isFirstSkillCooldown = false;
    }

    IEnumerator StartSecondSkillCooldown(float timeCD)
    {
        isSecondSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isSecondSkillCooldown = false;
    }

    public void OnLevelChangeEvent()
    {
        HandleLevelUp();
    }

    private void Start()
    {
        HandleLevelUp();
        isMoveSkillCooldown = false;
    }
}
