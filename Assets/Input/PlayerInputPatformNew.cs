using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Events;
public class PlayerInputPatformNew : PlayerSystem, PlayerControls.IPlayerInputActions, PlayerControls.IMenuActions, PlayerControls.IDealthMenuActions
{
    PlayerControls inputActions;

    public UnityEvent onMenu;
    public Vector2DEvent MovementInput;
    public Vector2 MovementVector { get;private set; }
    public Vector2 MousePos { get; private set; }

   
    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerControls();
        inputActions.Menu.SetCallbacks(this);
        inputActions.PlayerInput.SetCallbacks(this);
        inputActions.PlayerInput.Enable();
    }
   


    public void OnExitMenu(InputAction.CallbackContext context)
    {
        inputActions.PlayerInput.Enable();
        inputActions.Menu.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        this.MovementVector = context.ReadValue<Vector2>();
        MovementInput?.Invoke(MovementVector);

    }

    public void OnPointerPosition(InputAction.CallbackContext context)
    {
       
        UnityEngine.Vector3 mousePos = context.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        player.ID.playerEvents.OnMousePointer?.Invoke(Camera.main.ScreenToWorldPoint(mousePos));
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        inputActions.PlayerInput.Disable();
        inputActions.Menu.Enable();
        if (context.phase == InputActionPhase.Performed)
        {
            onMenu?.Invoke();
        }
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
       if(context.phase == InputActionPhase.Performed) {

            player.ID.playerEvents.OnAttack?.Invoke();
       
       }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            print("OnAttak");
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

}

[Serializable]
public class Vector2DEvent : UnityEvent<Vector2> { }

