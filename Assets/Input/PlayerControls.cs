//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""6e9f4809-77bc-44db-826a-1d9ed79883a1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7aae9cad-c9f5-4168-8e99-fc20ac13a17c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""46b33ffc-24c8-42cf-b4b6-d3ebea547e69"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""399ee80b-ead3-42a2-9ce8-4208e665e48c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillOne"",
                    ""type"": ""Button"",
                    ""id"": ""a6a02e26-308a-443a-8456-3720e36b9318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""bfbf1cba-1965-41d1-a2ca-e1f018e8df6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementSkill"",
                    ""type"": ""Button"",
                    ""id"": ""99ca928b-215f-4bd6-b48c-e9b9729eec2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZoomMap"",
                    ""type"": ""Button"",
                    ""id"": ""4044a982-5f8c-434b-8f9a-ed53b3bd08fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""53b368e5-415e-4ebf-a34b-3056cd94b0db"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3efbcdf6-e0e2-4c97-805a-3f1edd60e83b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2dbcfc4c-6a49-4371-9121-974988637f6d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""72d35162-fb59-447e-b442-25ad8ef58c0c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""17fae267-7748-47db-a20b-ed2ab50a1441"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f097a1a-86fe-4989-92b6-a69ca1704321"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKey"",
                    ""id"": ""f922dbcf-1a70-4b02-9523-5bf9a274a9c5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1be5c36f-7a13-46aa-89b5-95981fbee45b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b3fe5c7e-718f-431c-94cc-9e884ee64fe6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19d3fc24-9689-419e-a6ee-440137ccfb1f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87ef5d2b-1a6f-4a94-8962-acd2c482fddd"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fcd53f1e-a273-4c02-8e7f-f600a1d7b176"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2b62ecd-f4e7-42e4-8680-3f270a9c9534"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc7398a8-2e8e-4e26-8fa5-dec658ac11b4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""064e8231-c22b-4f8b-9c47-9177802ce488"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cf76d72-81ea-423a-ad2b-97c9445e8cd5"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""8b9098dd-08c5-44db-8378-a493bc14d15a"",
            ""actions"": [
                {
                    ""name"": ""ExitMenu"",
                    ""type"": ""Button"",
                    ""id"": ""cb1097e2-c267-4c30-8d56-7ee13c8a13be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7fe6ea4e-d4d8-4758-9ada-c0092b0976d9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DealthMenu"",
            ""id"": ""20e87d9f-1040-493c-842d-ffc75224ccef"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""60672f23-eae9-4b69-b589-b5bd99d80cc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d55b3d8-13d5-408b-bd8a-c9e279978a4a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""395ff500-d29c-4b59-a28e-d05504c8d0c4"",
                    ""path"": ""<Touchscreen>/touch*/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Movement = m_PlayerInput.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInput_PointerPosition = m_PlayerInput.FindAction("PointerPosition", throwIfNotFound: true);
        m_PlayerInput_Attack = m_PlayerInput.FindAction("Attack", throwIfNotFound: true);
        m_PlayerInput_SkillOne = m_PlayerInput.FindAction("SkillOne", throwIfNotFound: true);
        m_PlayerInput_OpenMenu = m_PlayerInput.FindAction("OpenMenu", throwIfNotFound: true);
        m_PlayerInput_MovementSkill = m_PlayerInput.FindAction("MovementSkill", throwIfNotFound: true);
        m_PlayerInput_ZoomMap = m_PlayerInput.FindAction("ZoomMap", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_ExitMenu = m_Menu.FindAction("ExitMenu", throwIfNotFound: true);
        // DealthMenu
        m_DealthMenu = asset.FindActionMap("DealthMenu", throwIfNotFound: true);
        m_DealthMenu_Click = m_DealthMenu.FindAction("Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private List<IPlayerInputActions> m_PlayerInputActionsCallbackInterfaces = new List<IPlayerInputActions>();
    private readonly InputAction m_PlayerInput_Movement;
    private readonly InputAction m_PlayerInput_PointerPosition;
    private readonly InputAction m_PlayerInput_Attack;
    private readonly InputAction m_PlayerInput_SkillOne;
    private readonly InputAction m_PlayerInput_OpenMenu;
    private readonly InputAction m_PlayerInput_MovementSkill;
    private readonly InputAction m_PlayerInput_ZoomMap;
    public struct PlayerInputActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerInputActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInput_Movement;
        public InputAction @PointerPosition => m_Wrapper.m_PlayerInput_PointerPosition;
        public InputAction @Attack => m_Wrapper.m_PlayerInput_Attack;
        public InputAction @SkillOne => m_Wrapper.m_PlayerInput_SkillOne;
        public InputAction @OpenMenu => m_Wrapper.m_PlayerInput_OpenMenu;
        public InputAction @MovementSkill => m_Wrapper.m_PlayerInput_MovementSkill;
        public InputAction @ZoomMap => m_Wrapper.m_PlayerInput_ZoomMap;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @PointerPosition.started += instance.OnPointerPosition;
            @PointerPosition.performed += instance.OnPointerPosition;
            @PointerPosition.canceled += instance.OnPointerPosition;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @SkillOne.started += instance.OnSkillOne;
            @SkillOne.performed += instance.OnSkillOne;
            @SkillOne.canceled += instance.OnSkillOne;
            @OpenMenu.started += instance.OnOpenMenu;
            @OpenMenu.performed += instance.OnOpenMenu;
            @OpenMenu.canceled += instance.OnOpenMenu;
            @MovementSkill.started += instance.OnMovementSkill;
            @MovementSkill.performed += instance.OnMovementSkill;
            @MovementSkill.canceled += instance.OnMovementSkill;
            @ZoomMap.started += instance.OnZoomMap;
            @ZoomMap.performed += instance.OnZoomMap;
            @ZoomMap.canceled += instance.OnZoomMap;
        }

        private void UnregisterCallbacks(IPlayerInputActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @PointerPosition.started -= instance.OnPointerPosition;
            @PointerPosition.performed -= instance.OnPointerPosition;
            @PointerPosition.canceled -= instance.OnPointerPosition;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @SkillOne.started -= instance.OnSkillOne;
            @SkillOne.performed -= instance.OnSkillOne;
            @SkillOne.canceled -= instance.OnSkillOne;
            @OpenMenu.started -= instance.OnOpenMenu;
            @OpenMenu.performed -= instance.OnOpenMenu;
            @OpenMenu.canceled -= instance.OnOpenMenu;
            @MovementSkill.started -= instance.OnMovementSkill;
            @MovementSkill.performed -= instance.OnMovementSkill;
            @MovementSkill.canceled -= instance.OnMovementSkill;
            @ZoomMap.started -= instance.OnZoomMap;
            @ZoomMap.performed -= instance.OnZoomMap;
            @ZoomMap.canceled -= instance.OnZoomMap;
        }

        public void RemoveCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_Menu_ExitMenu;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitMenu => m_Wrapper.m_Menu_ExitMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @ExitMenu.started += instance.OnExitMenu;
            @ExitMenu.performed += instance.OnExitMenu;
            @ExitMenu.canceled += instance.OnExitMenu;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @ExitMenu.started -= instance.OnExitMenu;
            @ExitMenu.performed -= instance.OnExitMenu;
            @ExitMenu.canceled -= instance.OnExitMenu;
        }

        public void RemoveCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // DealthMenu
    private readonly InputActionMap m_DealthMenu;
    private List<IDealthMenuActions> m_DealthMenuActionsCallbackInterfaces = new List<IDealthMenuActions>();
    private readonly InputAction m_DealthMenu_Click;
    public struct DealthMenuActions
    {
        private @PlayerControls m_Wrapper;
        public DealthMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_DealthMenu_Click;
        public InputActionMap Get() { return m_Wrapper.m_DealthMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DealthMenuActions set) { return set.Get(); }
        public void AddCallbacks(IDealthMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Add(instance);
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
        }

        private void UnregisterCallbacks(IDealthMenuActions instance)
        {
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
        }

        public void RemoveCallbacks(IDealthMenuActions instance)
        {
            if (m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDealthMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_DealthMenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DealthMenuActions @DealthMenu => new DealthMenuActions(this);
    public interface IPlayerInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSkillOne(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnMovementSkill(InputAction.CallbackContext context);
        void OnZoomMap(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnExitMenu(InputAction.CallbackContext context);
    }
    public interface IDealthMenuActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
}
