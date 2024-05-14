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
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""399ee80b-ead3-42a2-9ce8-4208e665e48c"",
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
                    ""name"": ""ZoomMap"",
                    ""type"": ""Button"",
                    ""id"": ""4044a982-5f8c-434b-8f9a-ed53b3bd08fa"",
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
                    ""name"": ""SkillSecond"",
                    ""type"": ""Button"",
                    ""id"": ""49466d7f-da40-48bc-91c9-b1b61fffe6ec"",
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
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""9d540306-0736-4bd9-9217-b0fadccd0c0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseMedit"",
                    ""type"": ""Button"",
                    ""id"": ""36ebacc7-280f-4b8f-a6c2-18ac5ea1b622"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseAmmoBox"",
                    ""type"": ""Button"",
                    ""id"": ""aa2b336d-df50-467d-bd01-f0d446ca9c9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6998b8c2-6fed-47c7-83bb-99a952b7aafa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
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
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
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
                    ""id"": ""1cf76d72-81ea-423a-ad2b-97c9445e8cd5"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d3cb6a1-4bf6-493a-9389-d60c42b75de9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillSecond"",
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
                    ""id"": ""c16da323-ce4c-4a1b-88ac-e61e27577e3d"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""111b5c18-2b7a-4f43-8271-830e89453fda"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseMedit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f3c1948-2b6f-4138-ba46-145b2eb7f27b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAmmoBox"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eeace21-fd0e-4cc0-afee-57a68fb26e68"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
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
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Inventory "",
            ""id"": ""b044697c-27be-4b3d-87b4-46a4feb08592"",
            ""actions"": [
                {
                    ""name"": ""CloseInventory"",
                    ""type"": ""Button"",
                    ""id"": ""cb00b76d-14e2-47fa-87cc-1f8a7d5f7c6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c8d2479-e11b-4ded-a963-04d0b3a0d8b3"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""3c64369f-5a90-4d61-a0d9-c51001ad58a7"",
            ""actions"": [
                {
                    ""name"": ""Skipline"",
                    ""type"": ""Button"",
                    ""id"": ""4e62de73-f715-4f2c-ab44-5631949d65bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eb5cd883-67b3-4290-ab5c-7f08304f6c68"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skipline"",
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
        m_PlayerInput_Press = m_PlayerInput.FindAction("Press", throwIfNotFound: true);
        m_PlayerInput_OpenMenu = m_PlayerInput.FindAction("OpenMenu", throwIfNotFound: true);
        m_PlayerInput_ZoomMap = m_PlayerInput.FindAction("ZoomMap", throwIfNotFound: true);
        m_PlayerInput_SkillOne = m_PlayerInput.FindAction("SkillOne", throwIfNotFound: true);
        m_PlayerInput_SkillSecond = m_PlayerInput.FindAction("SkillSecond", throwIfNotFound: true);
        m_PlayerInput_MovementSkill = m_PlayerInput.FindAction("MovementSkill", throwIfNotFound: true);
        m_PlayerInput_OpenInventory = m_PlayerInput.FindAction("OpenInventory", throwIfNotFound: true);
        m_PlayerInput_UseMedit = m_PlayerInput.FindAction("UseMedit", throwIfNotFound: true);
        m_PlayerInput_UseAmmoBox = m_PlayerInput.FindAction("UseAmmoBox", throwIfNotFound: true);
        m_PlayerInput_Interact = m_PlayerInput.FindAction("Interact", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_ExitMenu = m_Menu.FindAction("ExitMenu", throwIfNotFound: true);
        // DealthMenu
        m_DealthMenu = asset.FindActionMap("DealthMenu", throwIfNotFound: true);
        // Inventory 
        m_Inventory = asset.FindActionMap("Inventory ", throwIfNotFound: true);
        m_Inventory_CloseInventory = m_Inventory.FindAction("CloseInventory", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Skipline = m_Dialogue.FindAction("Skipline", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerInput_Press;
    private readonly InputAction m_PlayerInput_OpenMenu;
    private readonly InputAction m_PlayerInput_ZoomMap;
    private readonly InputAction m_PlayerInput_SkillOne;
    private readonly InputAction m_PlayerInput_SkillSecond;
    private readonly InputAction m_PlayerInput_MovementSkill;
    private readonly InputAction m_PlayerInput_OpenInventory;
    private readonly InputAction m_PlayerInput_UseMedit;
    private readonly InputAction m_PlayerInput_UseAmmoBox;
    private readonly InputAction m_PlayerInput_Interact;
    public struct PlayerInputActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerInputActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInput_Movement;
        public InputAction @PointerPosition => m_Wrapper.m_PlayerInput_PointerPosition;
        public InputAction @Press => m_Wrapper.m_PlayerInput_Press;
        public InputAction @OpenMenu => m_Wrapper.m_PlayerInput_OpenMenu;
        public InputAction @ZoomMap => m_Wrapper.m_PlayerInput_ZoomMap;
        public InputAction @SkillOne => m_Wrapper.m_PlayerInput_SkillOne;
        public InputAction @SkillSecond => m_Wrapper.m_PlayerInput_SkillSecond;
        public InputAction @MovementSkill => m_Wrapper.m_PlayerInput_MovementSkill;
        public InputAction @OpenInventory => m_Wrapper.m_PlayerInput_OpenInventory;
        public InputAction @UseMedit => m_Wrapper.m_PlayerInput_UseMedit;
        public InputAction @UseAmmoBox => m_Wrapper.m_PlayerInput_UseAmmoBox;
        public InputAction @Interact => m_Wrapper.m_PlayerInput_Interact;
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
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
            @OpenMenu.started += instance.OnOpenMenu;
            @OpenMenu.performed += instance.OnOpenMenu;
            @OpenMenu.canceled += instance.OnOpenMenu;
            @ZoomMap.started += instance.OnZoomMap;
            @ZoomMap.performed += instance.OnZoomMap;
            @ZoomMap.canceled += instance.OnZoomMap;
            @SkillOne.started += instance.OnSkillOne;
            @SkillOne.performed += instance.OnSkillOne;
            @SkillOne.canceled += instance.OnSkillOne;
            @SkillSecond.started += instance.OnSkillSecond;
            @SkillSecond.performed += instance.OnSkillSecond;
            @SkillSecond.canceled += instance.OnSkillSecond;
            @MovementSkill.started += instance.OnMovementSkill;
            @MovementSkill.performed += instance.OnMovementSkill;
            @MovementSkill.canceled += instance.OnMovementSkill;
            @OpenInventory.started += instance.OnOpenInventory;
            @OpenInventory.performed += instance.OnOpenInventory;
            @OpenInventory.canceled += instance.OnOpenInventory;
            @UseMedit.started += instance.OnUseMedit;
            @UseMedit.performed += instance.OnUseMedit;
            @UseMedit.canceled += instance.OnUseMedit;
            @UseAmmoBox.started += instance.OnUseAmmoBox;
            @UseAmmoBox.performed += instance.OnUseAmmoBox;
            @UseAmmoBox.canceled += instance.OnUseAmmoBox;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IPlayerInputActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @PointerPosition.started -= instance.OnPointerPosition;
            @PointerPosition.performed -= instance.OnPointerPosition;
            @PointerPosition.canceled -= instance.OnPointerPosition;
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
            @OpenMenu.started -= instance.OnOpenMenu;
            @OpenMenu.performed -= instance.OnOpenMenu;
            @OpenMenu.canceled -= instance.OnOpenMenu;
            @ZoomMap.started -= instance.OnZoomMap;
            @ZoomMap.performed -= instance.OnZoomMap;
            @ZoomMap.canceled -= instance.OnZoomMap;
            @SkillOne.started -= instance.OnSkillOne;
            @SkillOne.performed -= instance.OnSkillOne;
            @SkillOne.canceled -= instance.OnSkillOne;
            @SkillSecond.started -= instance.OnSkillSecond;
            @SkillSecond.performed -= instance.OnSkillSecond;
            @SkillSecond.canceled -= instance.OnSkillSecond;
            @MovementSkill.started -= instance.OnMovementSkill;
            @MovementSkill.performed -= instance.OnMovementSkill;
            @MovementSkill.canceled -= instance.OnMovementSkill;
            @OpenInventory.started -= instance.OnOpenInventory;
            @OpenInventory.performed -= instance.OnOpenInventory;
            @OpenInventory.canceled -= instance.OnOpenInventory;
            @UseMedit.started -= instance.OnUseMedit;
            @UseMedit.performed -= instance.OnUseMedit;
            @UseMedit.canceled -= instance.OnUseMedit;
            @UseAmmoBox.started -= instance.OnUseAmmoBox;
            @UseAmmoBox.performed -= instance.OnUseAmmoBox;
            @UseAmmoBox.canceled -= instance.OnUseAmmoBox;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
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
    public struct DealthMenuActions
    {
        private @PlayerControls m_Wrapper;
        public DealthMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_DealthMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DealthMenuActions set) { return set.Get(); }
        public void AddCallbacks(IDealthMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DealthMenuActionsCallbackInterfaces.Add(instance);
        }

        private void UnregisterCallbacks(IDealthMenuActions instance)
        {
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

    // Inventory 
    private readonly InputActionMap m_Inventory;
    private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();
    private readonly InputAction m_Inventory_CloseInventory;
    public struct InventoryActions
    {
        private @PlayerControls m_Wrapper;
        public InventoryActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseInventory => m_Wrapper.m_Inventory_CloseInventory;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void AddCallbacks(IInventoryActions instance)
        {
            if (instance == null || m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
            @CloseInventory.started += instance.OnCloseInventory;
            @CloseInventory.performed += instance.OnCloseInventory;
            @CloseInventory.canceled += instance.OnCloseInventory;
        }

        private void UnregisterCallbacks(IInventoryActions instance)
        {
            @CloseInventory.started -= instance.OnCloseInventory;
            @CloseInventory.performed -= instance.OnCloseInventory;
            @CloseInventory.canceled -= instance.OnCloseInventory;
        }

        public void RemoveCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInventoryActions instance)
        {
            foreach (var item in m_Wrapper.m_InventoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private List<IDialogueActions> m_DialogueActionsCallbackInterfaces = new List<IDialogueActions>();
    private readonly InputAction m_Dialogue_Skipline;
    public struct DialogueActions
    {
        private @PlayerControls m_Wrapper;
        public DialogueActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skipline => m_Wrapper.m_Dialogue_Skipline;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void AddCallbacks(IDialogueActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogueActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Add(instance);
            @Skipline.started += instance.OnSkipline;
            @Skipline.performed += instance.OnSkipline;
            @Skipline.canceled += instance.OnSkipline;
        }

        private void UnregisterCallbacks(IDialogueActions instance)
        {
            @Skipline.started -= instance.OnSkipline;
            @Skipline.performed -= instance.OnSkipline;
            @Skipline.canceled -= instance.OnSkipline;
        }

        public void RemoveCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogueActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogueActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    public interface IPlayerInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnZoomMap(InputAction.CallbackContext context);
        void OnSkillOne(InputAction.CallbackContext context);
        void OnSkillSecond(InputAction.CallbackContext context);
        void OnMovementSkill(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnUseMedit(InputAction.CallbackContext context);
        void OnUseAmmoBox(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnExitMenu(InputAction.CallbackContext context);
    }
    public interface IDealthMenuActions
    {
    }
    public interface IInventoryActions
    {
        void OnCloseInventory(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnSkipline(InputAction.CallbackContext context);
    }
}
