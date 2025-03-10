using PlayerController;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
[RequireComponent(typeof(Duration))]

public class SkillManager : PlayerSystem
{
    public BoolEvent OnUsingMoveSkill;
    private Duration duration;
    private PlayerHealth health;
    private BasicGun currentGun;
    public AudioClip levelUpSound;
    private AudioSource audioSource;

    [SerializeField]
    private UISKillController skillUI;
    [SerializeField]
    protected AbstractSkill moveSkill;
    [SerializeField]
    protected AbstractSkill firstSkill;
    [SerializeField]
    protected AbstractSkill secondSkill;

    protected bool isMoveSkillCooldown = false;
    protected bool isFirstSkillCooldown = false;
    protected bool isSecondSkillCooldown = false;

    private void Start()
    {
        currentGun = GetComponentInChildren<BasicGun>();
        audioSource = GetComponent<AudioSource>();

        HandleLevelUp();
        OnUpdateExp();
    }

    private void OnUpdateExp()
    {
        skillUI.UpdateExp(player.playerStats.xp, player.playerStats.levelUpXpRequire);
    }
    protected override void Awake()
    {
        base.Awake();
        duration = GetComponent<Duration>();
        health = GetComponent<PlayerHealth>();
    }
    private void OnEnable()
    {
        player.ID.playerEvents.OnMoveSkillUsed += OnMoveSkillUse;
        player.ID.playerEvents.OnSkillSecondUsed += OnSecondSkillUse;
        player.ID.playerEvents.OnFirstSkillUsed += OnFirstSkillUse;
        player.ID.playerEvents.OnLevelUp += OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing += UsingSkillTrigger;
        player.ID.playerEvents.OnChangeGun += OnChangeGun;
        player.ID.playerEvents.OnAddXp += OnUpdateExp;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMoveSkillUsed -= OnMoveSkillUse;
        player.ID.playerEvents.OnSkillSecondUsed -= OnSecondSkillUse;
        player.ID.playerEvents.OnFirstSkillUsed -= OnFirstSkillUse;
        player.ID.playerEvents.OnLevelUp -= OnLevelChangeEvent;
        player.ID.playerEvents.OnMoveSkillUsing -= UsingSkillTrigger;
        player.ID.playerEvents.OnChangeGun -= OnChangeGun;
        player.ID.playerEvents.OnAddXp -= OnUpdateExp;
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

        skillUI.SetLevel(level);

        audioSource.PlayOneShot(levelUpSound, 0.8f);

        if (level >= levelMoveSkillRequired && !isMoveSkillAdded)
        {
            if(PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1)
            {
                moveSkill = GetComponent<DashSkill>();
            }
            else
            {
                moveSkill = GetComponent<TeleportSkill>();
            }
            
            if (moveSkill == null) { print("chua lay dc"); }
            isMoveSkillAdded = true;
            moveSkill.canUse = true;
            skillUI.skillBox1.gameObject.SetActive(true);
        }

        if (level >= levelFirstSkillRequired && !isFirstSkillAdded)
        {
            if (PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1)
            {
                firstSkill = GetComponent<MineSkill>();
            }
            else
            {
                firstSkill = GetComponent<HealthSkill>();
            }
            
            if(firstSkill == null) { print("chua lay dc"); }
            isFirstSkillAdded = true;
            firstSkill.canUse = true;
            skillUI.skillBox2.gameObject.SetActive(true);
        }

        if (level >= levelSecondSkillRequired && !isSecondSkillAdded)
        {
            if (PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1)
            {
                secondSkill = GetComponent<EnhanceSkill>();
            }
            else
            {
                secondSkill = GetComponent<WallSkill>();
            }
            
            if (secondSkill == null) { print("chua lay dc"); }
            isSecondSkillAdded = true;
            secondSkill.canUse = true;
            skillUI.skillBox3.gameObject.SetActive(true);
        }
    }

    public void OnMoveSkillUse()
    {
        if (moveSkill == null)
        {
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
            return; 
        }

        int durationCost = firstSkill.GetDurationCost();
        if (PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1)
        {
            if (durationCost <= duration.CurrentDuration && !isFirstSkillCooldown)
            {
                firstSkill.OnUsed();
                duration.ReduceDuration(durationCost);
                StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
            }
        }
        else
        {
            if (durationCost <= duration.CurrentDuration && !isFirstSkillCooldown && !health.isFull)
            {
                firstSkill.OnUsed();
                duration.ReduceDuration(durationCost);
                StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
            }
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


        int durationCost = secondSkill.GetDurationCost();
        if (PlayerPrefs.GetInt("selectedOption") == 3 || PlayerPrefs.GetInt("selectedOption") == 1) 
        {
            if (secondSkill == null || !currentGun)
            {
                return;
            }
            
            if (durationCost <= duration.CurrentDuration && !isSecondSkillCooldown)
            {
                secondSkill.OnUsed();
                duration.ReduceDuration(durationCost);
                StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
            }
        }
        else
        {
            if (secondSkill == null)
            {
                return;
            }

            if (durationCost <= duration.CurrentDuration && !isSecondSkillCooldown)
            {
                secondSkill.OnUsed();
                duration.ReduceDuration(durationCost);
                StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
            }
        }

        
        if(durationCost > duration.CurrentDuration)
        {
            OnNotEnoughDuration();
        }
    }
    IEnumerator StartMoveSkillCooldown(float timeCD)
    {
        isMoveSkillCooldown = true;
        
        StartCoroutine(skillUI.skillBox1.UpdateCDSkill(timeCD));
        yield return new WaitForSeconds(timeCD);

        isMoveSkillCooldown = false;
    }
    IEnumerator StartFirstSkillCooldown(float timeCD)
    {
        isFirstSkillCooldown = true;

        StartCoroutine(skillUI.skillBox2.UpdateCDSkill(timeCD));
        yield return new WaitForSeconds(timeCD);

        isFirstSkillCooldown = false;
    }

    IEnumerator StartSecondSkillCooldown(float timeCD)
    {
        isSecondSkillCooldown = true;

        StartCoroutine(skillUI.skillBox3.UpdateCDSkill(timeCD));
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
}
