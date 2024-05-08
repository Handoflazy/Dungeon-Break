using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
[RequireComponent(typeof(Duration))]
[RequireComponent(typeof(SkillBarController))]
public class SkillManager : PlayerSystem
{
    public BoolEvent OnUsingMoveSkill;
    private Duration duration;
    private SkillBarController controller;

    public AbstractSkill moveSkill;
    public AbstractSkill firstSkill;
    public AbstractSkill secondSkill;

    public bool isMoveSkillCooldown = false;
    public bool isFirstSkillCooldown = false;
    public bool isSecondSkillCooldown = false;

    private void Start()
    {
        HandleLevelUp();
    }

    private void Update()
    {

    }
    protected override void Awake()
    {
        base.Awake();
        duration = GetComponent<Duration>();
        controller = GetComponent<SkillBarController>();
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
            moveSkill = GetComponent<DashSkill>();
            if (moveSkill == null) { print("chua lay dc"); }
            isMoveSkillAdded = true;
            moveSkill.canUse = true;
            controller.skillBox1.gameObject.SetActive(true);
        }

        if (level >= 10 && !isFirstSkillAdded)
        {
            firstSkill = GetComponent<MineSkill>();
            if(firstSkill == null) { print("chua lay dc"); }
            isFirstSkillAdded = true;
            firstSkill.canUse = true;
            controller.skillBox2.gameObject.SetActive(true);
        }

        if (level >= 15 && !isSecondSkillAdded)
        {
            secondSkill = GetComponent<EnhanceSkill>();
            if (secondSkill == null) { print("chua lay dc"); }
            isSecondSkillAdded = true;
            secondSkill.canUse = true;
            controller.skillBox3.gameObject.SetActive(true);
        }
    }

    public void OnMoveSkillUse()
    {
        if (!moveSkill) return;

        int durationCost = moveSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isMoveSkillCooldown)
        {
            moveSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartMoveSkillCooldown(moveSkill.GetCowndown()));
        }
    }

    public void OnFirstSkillUse()
    {
        if (firstSkill == null) return;

        int durationCost = firstSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isFirstSkillCooldown)
        {
            firstSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
        }
    }

    public void OnSecondSkillUse()
    {
        if (secondSkill == null) return;

        int durationCost = secondSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isSecondSkillCooldown)
        {
            secondSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
        }
    }
    IEnumerator StartMoveSkillCooldown(float timeCD)
    {
        isMoveSkillCooldown = true;
        
        StartCoroutine(controller.UpdateCDMoveSkill(timeCD));
        yield return new WaitForSeconds(timeCD);

        isMoveSkillCooldown = false;
    }
    IEnumerator StartFirstSkillCooldown(float timeCD)
    {
        isFirstSkillCooldown = true;

        StartCoroutine(controller.UpdateCDFirstSkill(timeCD));
        yield return new WaitForSeconds(timeCD);

        isFirstSkillCooldown = false;
    }

    IEnumerator StartSecondSkillCooldown(float timeCD)
    {
        isSecondSkillCooldown = true;

        StartCoroutine(controller.UpdateCDSecondSkill(timeCD));
        yield return new WaitForSeconds(timeCD);

        isSecondSkillCooldown = false;
    }

    public void OnLevelChangeEvent()
    {
        HandleLevelUp();
    }
}
