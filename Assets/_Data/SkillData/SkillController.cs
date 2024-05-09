//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class SkillController : MonoBehaviour
//{
//    public SkillType type;

//    private bool isActive;
//    private bool isCooldown;

//    private float activeTime; //thoi gian hoat dong tinh tu luc bat dau
//    private float cooldownTime; //thoi gian cooldown tinh tu luc bat dau

//    public UnityEvent OnActive;
//    public UnityEvent OnCooldown;
//    public UnityEvent OnUpdate;

//    public float cooldownProgress
//    {
//        get => cooldownTime / skillStat.cooldown;
//    }
//    public float activeProgress
//    {
//        get => activeTime / skillStat.timeActive;
//    }
//    public bool IsActive { get => isActive;}
//    public bool IsCooldown { get => isCooldown;}
//    public float ActiveTime { get => activeTime;}
//    public float CooldownTime { get => cooldownTime;}

//    public void LoadStat()
//    {
//        if (skillStat == null) return;
//        cooldownTime = skillStat.cooldown;
//        activeTime = skillStat.timeActive;
//    }
//    public void Active()
//    {
//        if (isActive || isCooldown) return;
//        isActive = true;
//        isCooldown = true;

//        OnActive?.Invoke();
//    }
//    private void Update()
//    {
//        OnCoreHandle();
//    }
//    private void OnCoreHandle()
//    {
//        ReduceActiveTime();
//        ReduceCooldownTime();
//    }
//    public void ReduceActiveTime()
//    {
//        if (!isActive) return;
//        activeTime -= Time.deltaTime;
//        if (activeTime <= 0)
//        {
//            Stop();
//        }
//        OnUpdate?.Invoke();
//    }

//    private void Stop()
//    {
//        activeTime = skillStat.timeActive;
//        isActive = false;
//    }

//    public void ReduceCooldownTime()
//    {
//        if (!isCooldown) return;
//        cooldownTime -= Time.deltaTime;
//        OnCooldown?.Invoke();
//        if (cooldownTime > 0) return;
//        isCooldown = false;
//        cooldownTime = skillStat.cooldown;
//    }
//    public void ForceStop()
//    {
//        isActive = false;
//        isCooldown = false;
//        LoadStat();
//    }
//}
