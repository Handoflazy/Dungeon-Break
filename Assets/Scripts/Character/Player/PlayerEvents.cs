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
    public  Action<Vector2> OnMousePointer;

    public Action<int> OnToggleActiveSlot;
    public Action OnInventoryToggle;


    public Action OnZoomCamera;

    //Animated Character
    
    public Action OnChangeSide;
    public Action<bool> OnLeftSide;

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
    public Action<int> onInitialDuration;
    //Stats Event;
    public Action OnAddXp;
    public Action OnLevelUp;


    // State Events
    public Action onRespawn;

    //Weapon Events
    public Action OnUseWeapon;
    public Action<bool> OnUsingWeapon;
    public Action<Weapon> OnChangeWeapon;

    //Combat Events;
    public Action<Vector2> OnBeginPush;


    //Consume Event
    // Scene Event

    public Action OnSceneLoad;
   


}
[Serializable]
public class IntEvent : UnityEvent<int> { }
[Serializable]
public class BoolEvent: UnityEvent<bool> { }    