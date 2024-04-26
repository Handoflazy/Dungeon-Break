using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.TimeZoneInfo;

public class FirstSkillManager : MonoBehaviour
{
}

public interface IFirstSkill { }

public class Wideslash : AbstractSkill, IFirstSkill
{
    [SerializeField] 
    private Animator Anim;


    private void Start()
    {
       // Anim = GetComponent<SkillManager>().currentWeapon.gameObject.GetComponent<Animator>();
    }

    private readonly int wideSlash = Animator.StringToHash("WideSlash");
  

    public override void OnUsed()
    {
       
            Anim.Play(wideSlash);
            print(1);
        
    }
}

