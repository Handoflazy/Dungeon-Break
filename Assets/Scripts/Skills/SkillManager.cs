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
    [field:SerializeField]
    public Weapon CurrentWeapon { get; set; }

    private Duration duration;

    public WeaponType weaponType;

    public IMoveSkill iMoveSkill;

    private AbstractSkill moveSkill;
    private AbstractSkill firstSkill;
    private AbstractSkill secondSkill;

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
        player.ID.playerEvents.OnMoveSkillUsed += OnMoveSkillUse;
        //player.ID.playerEvents.OnChangeWeapon += OnWeaponChangeEvent;
        player.ID.playerEvents.OnLevelUp += OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing += UsingSkillTrigger;
        player.ID.playerEvents.OnSkillSecondUsed += OnSecondSkillUse;
        player.ID.playerEvents.OnSkillOneUsed += OnFirstSkillUse;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMoveSkillUsed -= OnMoveSkillUse;
        //player.ID.playerEvents.OnChangeWeapon -= OnWeaponChangeEvent;
        player.ID.playerEvents.OnLevelUp -= OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= UsingSkillTrigger;
        player.ID.playerEvents.OnSkillSecondUsed -= OnSecondSkillUse;
        player.ID.playerEvents.OnSkillSecondUsed -= OnFirstSkillUse;
    }

    void UsingSkillTrigger(bool isUsing)
    {
        OnUsingMoveSkill?.Invoke(isUsing);
    }

    private void HandleLevelUp()
    {
        int level = player.playerStats.level;
        Component c = gameObject.GetComponent<IMoveSkill>() as Component;
        Component e = gameObject.GetComponent<IFirstSkill>() as Component;
        Component d = gameObject.GetComponent<ISecondSkill>() as Component;
        if (c != null)
        {
            Destroy(c);
        }
        if (d != null)
        {
            Destroy(d);
        }
        if (e != null)
        {
            Destroy(e);
        }

        if(level >= 5 && level < 10)
        {
            moveSkill = gameObject.AddComponent<DashSkill>();
            firstSkill = null;
            secondSkill = null;
        }
        else if(level >= 10 && level < 15)
        {
            moveSkill = gameObject.AddComponent<DashSkill>();
            firstSkill = gameObject.AddComponent<BackStepSkill>();
            secondSkill = null;
        }
        else if(level >= 15 /*&& level < 20*/)
        {
            moveSkill = gameObject.AddComponent<DashSkill>();
            firstSkill = gameObject.AddComponent<BackStepSkill>();
            secondSkill = gameObject.AddComponent<TeleportSkill>();
        }
        else
        {
            moveSkill = null;
            secondSkill = null;
            firstSkill = null;
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
        if (durationCost < duration.CurrentDuration && !isAttackSkillCooldown)
        {
            secondSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartAttackSkillCooldown(secondSkill.GetCowndown()));
        }
    }
    public void OnFirstSkillUse()
    {

        if (firstSkill == null)
            return;
        int durationCost = firstSkill.GetDurationCost();
        if (durationCost < duration.CurrentDuration && !isAttackSkillCooldown)
        {

            firstSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartAttackSkillCooldown(firstSkill.GetCowndown()));
        }
    }
    IEnumerator StartMoveSkillCooldown(float timeCD)
    {
        isMoveSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isMoveSkillCooldown = false;

    }
    IEnumerator StartAttackSkillCooldown(float timeCD)
    {
        isAttackSkillCooldown = true;
        yield return new WaitForSeconds(timeCD);
        isAttackSkillCooldown = false;
    }

    public void OnLevelChangeEvent()
    {
        HandleLevelUp();
    }

    private void Start()
    {
        //HandleWeaponType();
        HandleLevelUp();
        isMoveSkillCooldown = false;
    }

    //private void LateUpdate()
    //{
    //    HandleLevelUp();
    //}


    //private void HandleWeaponType()
    //{
    //    if (CurrentWeapon == null)
    //        return;
    //    Component c = gameObject.GetComponent<IMoveSkill>() as Component;
    //    Component e = gameObject.GetComponent<IFirstSkill>() as Component;
    //    Component d = gameObject.GetComponent<ISecondSkill>() as Component;
    //    if (c != null)
    //    {
    //        Destroy(c);
    //    }
    //    if (d != null)
    //    {
    //        Destroy(d);
    //    }
    //    if (e != null)
    //    {
    //        Destroy(e);
    //    }


    //    switch (weaponType)
    //    {
    //        case WeaponType.Melee:
    //            moveSkill = gameObject.AddComponent<DashSkill>();
    //            secondSkill = gameObject.AddComponent<Giganize>();
    //            firstSkill = gameObject.AddComponent<Wideslash>();

    //            break;
    //        case WeaponType.Range:
    //            moveSkill = gameObject.AddComponent<BackStepSkill>();
    //            secondSkill = gameObject.AddComponent<MultiArrowSkill>();
    //            firstSkill = gameObject.AddComponent<ExplosionArrowSkill>();
    //            break;
    //        case WeaponType.Staff:
    //            moveSkill = gameObject.AddComponent<TeleportSkill>();
    //            secondSkill = gameObject.AddComponent<MagicShield>();
    //            firstSkill = gameObject.AddComponent<FireballSkill>(); 
    //            break;
    //        default:
    //            moveSkill = null;
    //            secondSkill = null;
    //            firstSkill = null;
    //            break;
    //    }
    //}

    //public void OnWeaponChangeEvent(Weapon weapon)
    //{
    //    CurrentWeapon = weapon;
    //    if (weapon == null)
    //        return;
    //    weaponType = weapon.WeaponType;
    //    HandleWeaponType();
    //}


}


