using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
[RequireComponent(typeof(Duration))]
[RequireComponent(typeof(SkillBarController))]
public class SkillManager : PlayerSystem
{
    public BoolEvent OnUsingMoveSkill;
    private Duration duration;
    private SkillBarController controller;
    private BasicGun currentGun;
    public AudioClip levelUpSound;
    private AudioSource audioSource;

    protected AbstractSkill moveSkill;
    protected AbstractSkill firstSkill;
    protected AbstractSkill secondSkill;

    protected bool isMoveSkillCooldown = false;
    protected bool isFirstSkillCooldown = false;
    protected bool isSecondSkillCooldown = false;

    private void Start()
    {
        currentGun = GetComponentInChildren<BasicGun>();
        audioSource = GetComponent<AudioSource>();
        HandleLevelUp();
    }

    private void Update()
    {
        controller.UpdateExp();
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
        player.ID.playerEvents.OnSkillSecondUsed += OnSecondSkillUse;
        player.ID.playerEvents.OnFirstSkillUsed += OnFirstSkillUse;
        player.ID.playerEvents.OnLevelUp += OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing += UsingSkillTrigger;
        player.ID.playerEvents.OnChangeGun += OnChangeGun;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMoveSkillUsed -= OnMoveSkillUse;
        player.ID.playerEvents.OnSkillSecondUsed -= OnSecondSkillUse;
        player.ID.playerEvents.OnFirstSkillUsed -= OnFirstSkillUse;
        player.ID.playerEvents.OnLevelUp -= OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= UsingSkillTrigger;
        player.ID.playerEvents.OnChangeGun -= OnChangeGun;
    }

    void UsingSkillTrigger(bool isUsing)
    {
        OnUsingMoveSkill?.Invoke(isUsing);
    }

    private bool isMoveSkillAdded;
    private bool isFirstSkillAdded;
    private bool isSecondSkillAdded;

    private int levelMoveSkillRequired = 5;
    private int levelFirstSkillRequired = 10;
    private int levelSecondSkillRequired = 15;

    private void HandleLevelUp()
    {
        int level = player.playerStats.level;

        controller.SetLevel(level, controller.textLevel);

        audioSource.PlayOneShot(levelUpSound, 0.8f);

        if (level >= levelMoveSkillRequired && !isMoveSkillAdded)
        {
            moveSkill = GetComponent<DashSkill>();
            if (moveSkill == null) { print("chua lay dc"); }
            isMoveSkillAdded = true;
            moveSkill.canUse = true;
            controller.inactiveBox1.gameObject.SetActive(false);
        }

        if (level >= levelFirstSkillRequired && !isFirstSkillAdded)
        {
            firstSkill = GetComponent<MineSkill>();
            if(firstSkill == null) { print("chua lay dc"); }
            isFirstSkillAdded = true;
            firstSkill.canUse = true;
            controller.inactiveBox2.gameObject.SetActive(false);
        }

        if (level >= levelSecondSkillRequired && !isSecondSkillAdded)
        {
            secondSkill = GetComponent<EnhanceSkill>();
            if (secondSkill == null) { print("chua lay dc"); }
            isSecondSkillAdded = true;
            secondSkill.canUse = true;
            controller.inactiveBox3.gameObject.SetActive(false);
        }
    }

    public void OnMoveSkillUse()
    {
        if (moveSkill == null)
        {
            OnNotEnoughLevel(levelMoveSkillRequired);
            return;
        }

        int durationCost = moveSkill.GetDurationCost();
        if (durationCost <= duration.CurrentDuration && !isMoveSkillCooldown)
        {
            moveSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartMoveSkillCooldown(moveSkill.GetCowndown()));
        }
        if (durationCost > duration.CurrentDuration)
        {
            OnNotEnoughDuration();
        }
    }

    public void OnFirstSkillUse()
    {
        if (firstSkill == null) 
        {
            OnNotEnoughLevel(levelFirstSkillRequired);
            return; 
        }

        int durationCost = firstSkill.GetDurationCost();
        if (durationCost <= duration.CurrentDuration && !isFirstSkillCooldown)
        {
            firstSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
        }
        if (durationCost > duration.CurrentDuration)
        {
            OnNotEnoughDuration();
        }
    }

    public void OnSecondSkillUse()
    {
        if(secondSkill == null) { print("sck null"); }
        if (currentGun == null) { print("crg null"); }
        if (secondSkill == null || !currentGun) 
        {
            OnNotEnoughLevel(levelSecondSkillRequired);
            return; 
        }

        int durationCost = secondSkill.GetDurationCost();
        if (durationCost <= duration.CurrentDuration && !isSecondSkillCooldown)
        {
            secondSkill.OnUsed();
            duration.ReduceDuration(durationCost);
            StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
        }
        if(durationCost > duration.CurrentDuration)
        {
            OnNotEnoughDuration();
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

    public void OnChangeGun(BasicGun newGun)
    {
        currentGun = newGun;
    }

    private void OnNotEnoughDuration()
    {
        NguyenSingleton.Instance.FloatingTextManager.Show("Out of Duration", 24, Color.blue, transform.position, Vector3.up, 0.2f);
    }
    private void OnNotEnoughLevel(int level)
    {
        print("Level :"+player.playerStats.level);
        NguyenSingleton.Instance.FloatingTextManager.Show("Required level " + level + " !", 24, Color.yellow, transform.position, Vector3.down, 0.2f);
    }
}
