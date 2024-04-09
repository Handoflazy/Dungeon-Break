using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct PlayerEvents
{
    // Input Events

    public  Action OnAttack;
    public  Action<Vector2> OnMove;
    public  Action OnWeaponChage;
    public  Action<Vector2> OnMousePointer;

    //Animated Character
    
    public Action OnChangeSide;

    // UI Events
    public Action<int> OnHealthChanged;
    public Action<int> OnDurationChanged;
    public Action<int> OnLevelChanged;

    //Menu Events
    public Action OnMenuOpen;
    public Action OnMenuClose;

    //Movement Events;
    public Action<bool> OnMoveSkillUsing;


    // Skill Events
    public Action OnMoveSkillUsed;
    public Action OnSkillOneUsed;
    public Action OnSkillSecondUsed;

    // Collison Events
    public Action<int> onTakeDamage;

    // Health Events
    public Action onDeath;
    public Action<int> OnHeal;
    //Duration Events;
    public Action onOutOfDuration;
    public Action<int> OnRefillDuration;



    // State Events
    public Action onRespawn;

    //Weapon Events
    public Action OnUseWeapon;
    public Action<bool> OnUsingWeapon;

    //Combat Events;
    public Action<Vector2> OnBeginPush;


    //Consume Event

   


}
[Serializable]
public class IntEvent : UnityEvent<int> { }
[Serializable]
public class BoolEvent: UnityEvent<bool> { }    