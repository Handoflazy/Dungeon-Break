using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Events;
public class AgentInput : PlayerSystem, PlayerControls.IPlayerInputActions, PlayerControls.IMenuActions, PlayerControls.IDealthMenuActions, PlayerControls.IInventoryActions
{
    PlayerControls inputActions;
    public Vector2 MousePos { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerControls();
        inputActions.Menu.SetCallbacks(this);
        inputActions.PlayerInput.SetCallbacks(this);
        inputActions.Inventory.SetCallbacks(this);
        inputActions.PlayerInput.Enable();
    }



    public void OnExitMenu(InputAction.CallbackContext context)
    {
        inputActions.PlayerInput.Enable();
        inputActions.Menu.Disable();
        NguyenSingleton.Instance.UISettingController.CloseMenu();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        player.ID.playerEvents.OnMove?.Invoke(context.ReadValue<Vector2>());

    }

    public void OnPointerPosition(InputAction.CallbackContext context)
    {
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            inputActions.PlayerInput.Disable();
            inputActions.Menu.Enable();
            NguyenSingleton.Instance.UISettingController.OpenMenu();
        }
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {

            player.ID.playerEvents.OnAttack?.Invoke();

        }
    }


    public void OnSkillOne(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnSkillOneUsed?.Invoke();
        }
    }
    public void OnSkillSecond(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnSkillSecondUsed?.Invoke();
        }
    }

    public void OnMovementSkill(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnMoveSkillUsed?.Invoke();
        }
    }

    public void OnZoomMap(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnZoomCamera?.Invoke();
            
        }
    }

    public void OnKeyBoard(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnToggleActiveSlot?.Invoke((int)context.ReadValue<float>());

        }
    }

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            print("Open");
            inputActions.Inventory.Enable();
            inputActions.PlayerInput.Disable();
            player.ID.playerEvents.OnInventoryToggle?.Invoke();
        }
    }

    public void OnCloseInventory(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Performed)
        {
            print("Close");
            player.ID.playerEvents.OnInventoryToggle?.Invoke();
            inputActions.PlayerInput.Enable();
            inputActions.Inventory.Disable();
        }
    }


    public void OnPress(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnPressed?.Invoke(); 
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            player.ID.playerEvents.OnRelease?.Invoke();
        }
    }
}


