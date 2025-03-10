using Inventory.Model;
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
    public Action OnInventoryButtonToggle;
    public Action OnInventoryToggle;
    public Action OnPressed;
    public Action OnRelease;
    public Action OnUseMedit;
    public Action OnReloadBullet;

    public Action<int> OnQuickSlotToggle;


    public Action OnZoomCamera;

    //Animated Character
    
    public Action OnChangeSide;
    public Action<bool> OnLeftSide;
    public Action OnDeath;

    // UI Events
    public Action<int> OnHealthChanged;
    public Action<int> OnDurationChanged;
    public Action<int> OnLevelChanged;

    //Menu Events
    public Action OnMenuOpen;
    public Action OnMenuClose;

    public Action OnNewGame;

    // Dialogue Events;
    public Action OnDialogueStart;
    public Action OnDialogueEnd;

    

    //Movement Events;
    public Action<bool> OnMoveSkillUsing;


    // Skill Events
    public Action OnMoveSkillUsed;
    public Action OnFirstSkillUsed;
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
    public Action<BasicGun> OnChangeGun;
    public Action<int> OnUpdateAmmo;
    public Action<int> OnUpdateMedikit;
    public Action<int> OnUpdateAmmoBox;

    //Combat Events;
    public Action<Vector2> OnBeginPush;


    //Consume Event
    // Scene Event

    public Action OnSceneLoad;

    // Inventory Event

    public Action<ItemSO,int> OnDropItem;
   


}
[Serializable]
public class IntEvent : UnityEvent<int> { }
[Serializable]
public class BoolEvent: UnityEvent<bool> { }    