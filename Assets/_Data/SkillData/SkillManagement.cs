//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem.XR;
//[RequireComponent(typeof(Duration))]

//public class SkillManagement : PlayerSystem
//{
//    public BoolEvent OnUsingMoveSkill;
//    private Duration duration;

//    protected override void Awake()
//    {
//        base.Awake();
//        duration = GetComponent<Duration>();
//    }

//    [field: SerializeField]
//    private SkillSO DashSkill;
//    [field: SerializeField]
//    private SkillSO Mine;
//    [field: SerializeField]
//    private SkillSO Enhance;

//    private bool isMoveSkillAdded;
//    private bool isFirstSkillAdded;
//    private bool isSecondSkillAdded;

//    private void AddSkill()
//    {
//        int level = player.playerStats.level;

//        if (level >= 5 && !isMoveSkillAdded)
//        {
//            DashSkill = ScriptableObject.CreateInstance<SkillSO>();
//            moveSkill.Initialize();
//            isMoveSkillAdded = true;
//            controller.skillBox1.gameObject.SetActive(true);
//        }

//        if (level >= 10 && !isFirstSkillAdded)
//        {
//            firstSkill = gameObject.AddComponent<Grenade>();
//            isFirstSkillAdded = true;
//            controller.skillBox2.gameObject.SetActive(true);
//        }

//        if (level >= 15 && !isSecondSkillAdded)
//        {
//            secondSkill = gameObject.AddComponent<EnhanceSkill>();
//            isSecondSkillAdded = true;
//            controller.skillBox3.gameObject.SetActive(true);
//        }
//    }

//    public void OnMoveSkillUse()
//    {
//        if (!moveSkill)
//            return;
//        UseSkill(moveSkill); //test audio
//        int durationCost = moveSkill.GetDurationCost();
//        if (durationCost < duration.CurrentDuration && !isMoveSkillCooldown)
//        {
//            moveSkill.OnUsed();
//            duration.ReduceDuration(durationCost);
//            StartCoroutine(StartMoveSkillCooldown(moveSkill.GetCowndown()));
//        }
//    }

//    public void OnFirstSkillUse()
//    {

//        if (firstSkill == null)
//            return;
//        UseSkill(firstSkill); //test audio

//        int durationCost = firstSkill.GetDurationCost();
//        if (durationCost < duration.CurrentDuration && !isFirstSkillCooldown)
//        {

//            firstSkill.OnUsed();
//            duration.ReduceDuration(durationCost);
//            StartCoroutine(StartFirstSkillCooldown(firstSkill.GetCowndown()));
//        }
//    }

//    public void OnSecondSkillUse()
//    {

//        if (secondSkill == null)
//            return;
//        UseSkill(secondSkill); //test audio
//        int durationCost = secondSkill.GetDurationCost();
//        if (durationCost < duration.CurrentDuration && !isSecondSkillCooldown)
//        {
//            secondSkill.OnUsed();
//            duration.ReduceDuration(durationCost);
//            StartCoroutine(StartSecondSkillCooldown(secondSkill.GetCowndown()));
//        }
//    }
//    IEnumerator StartMoveSkillCooldown(float timeCD)
//    {
//        moveSkill.canUse = false; //6-5
//        isMoveSkillCooldown = true;
//        yield return new WaitForSeconds(timeCD);
//        isMoveSkillCooldown = false;
//        moveSkill.canUse = true; //6-5
//    }
//    IEnumerator StartFirstSkillCooldown(float timeCD)
//    {
//        firstSkill.canUse = false; //6-5
//        isFirstSkillCooldown = true;
//        yield return new WaitForSeconds(timeCD);
//        isFirstSkillCooldown = false;
//        firstSkill.canUse = true;
//    }

//    IEnumerator StartSecondSkillCooldown(float timeCD)
//    {
//        secondSkill.canUse = false; //6-5
//        isSecondSkillCooldown = true;
//        yield return new WaitForSeconds(timeCD);
//        isSecondSkillCooldown = false;
//        secondSkill.canUse = true;
//    }

//    public void OnLevelChangeEvent()
//    {
//        HandleLevelUp();
//    }

//    private void Start()
//    {
//        HandleLevelUp();
//        isMoveSkillCooldown = false;
//    }
//}
