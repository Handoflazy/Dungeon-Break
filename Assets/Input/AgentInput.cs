using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Events;
using Unity.VisualScripting;
//using static UnityEditor.Experimental.GraphView.GraphView;
public class AgentInput : PlayerSystem, PlayerControls.IPlayerInputActions, PlayerControls.IMenuActions, PlayerControls.IDealthMenuActions, PlayerControls.IInventoryActions, PlayerControls.IDialogueActions
{



    PlayerControls inputActions;
    public Vector2 MousePos { get; private set; }

    public bool Interact = false;


    private void OnEnable()
    {
        player.ID.playerEvents.OnMenuOpen += OnMenuOpen;
        player.ID.playerEvents.OnMenuClose += BackToDefaultInput;
        player.ID.playerEvents.OnDialogueStart += OnInDialogue;
        player.ID.playerEvents.OnDialogueEnd += BackToDefaultInput;
        player.ID.playerEvents.OnInventoryButtonToggle += ToggleInventoryAction;

    }

    private void OnDisable()
    {
        BackToDefaultInput();
        player.ID.playerEvents.OnMenuOpen -= OnMenuOpen;
        player.ID.playerEvents.OnMenuClose -= BackToDefaultInput;
        player.ID.playerEvents.OnDialogueStart -= OnInDialogue;
        player.ID.playerEvents.OnDialogueEnd -= BackToDefaultInput;
        player.ID.playerEvents.OnInventoryButtonToggle -= ToggleInventoryAction;
        TurnOffInput();

    }
    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerControls();
    }

    void Start()
    {
        inputActions.Menu.SetCallbacks(this);
        inputActions.PlayerInput.SetCallbacks(this);
        inputActions.Inventory.SetCallbacks(this);
        inputActions.Dialogue.SetCallbacks(this);
        inputActions.PlayerInput.Enable();
    }

    public void TurnOffInput() 
    {
        inputActions.PlayerInput.Disable();
    }
    public void OnMenuOpen()
    {
        SwitchActionMap(inputActions.Menu);
    }
    public void BackToDefaultInput()
    {
        SwitchActionMap(inputActions.PlayerInput);
    }
    public void OnDeathEvent()
    {
        inputActions.PlayerInput.Disable();
    }

    public void OnInDialogue()
    {
        SwitchActionMap(inputActions.Dialogue);
    }




    public void OnExitMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            BackToDefaultInput();
            NguyenSingleton.Instance.MenuController.CloseMenu(); 
        }
    }

    public void SwitchActionMap(InputActionMap targetMap)
    {
        // Tắt tất cả các action map hiện đang được kích hoạt
        foreach (var actionMap in inputActions.asset.actionMaps)
        {
            actionMap.Disable();
        }
        // Kích hoạt action map mong muốn
        targetMap.Enable();
        
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
            OnMenuOpen();
            NguyenSingleton.Instance.MenuController.OpenMenu();
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
            player.ID.playerEvents.OnFirstSkillUsed?.Invoke();
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
            ToggleInventoryAction();
        }
    }

    private void ToggleInventoryAction()
    {
        if (inputActions.PlayerInput.enabled)
        {
            SwitchActionMap(inputActions.Inventory);
        }
        else
        {
            BackToDefaultInput();
        }
        player.ID.playerEvents.OnInventoryToggle?.Invoke();
    }

    public void OnCloseInventory(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Performed)
        {
            ToggleInventoryAction();

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

    public void OnUseMedit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnUseMedit?.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Interact = false;
        }
        else
        {
            Interact = true;
        }

    }

    public void OnUseAmmoBox(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Performed)
        {
            player.ID.playerEvents.OnReloadBullet?.Invoke();
        }
    }

    public void OnSkipline(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Interact = false;
        }
        else
        {
            Interact = true;
        }
    }
}


