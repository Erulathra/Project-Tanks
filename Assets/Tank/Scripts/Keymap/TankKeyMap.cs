// GENERATED AUTOMATICALLY FROM 'Assets/Tank/Scripts/Keymap/TankKeyMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TankKeyMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TankKeyMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TankKeyMap"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""c588a0ac-b5cb-4a98-a73b-3806eeb114f7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d762f1e4-4a2b-4e5a-b770-a1685c64af75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""0a158e17-69b4-47b0-b76f-bf59915798e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4ae9608a-e450-4662-8550-a853ba8bb2ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateFront"",
                    ""type"": ""Value"",
                    ""id"": ""90d403f1-807e-4507-bbf1-f8dec613e74b"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateBack"",
                    ""type"": ""Value"",
                    ""id"": ""892025d6-735d-4e3f-8e75-0863b7a06da7"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""a92ad80c-74ed-4b7c-a0e6-40f7fac45433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbf6fac4-e864-4735-ba16-efdc1d574dcd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37219192-1e25-443f-9086-91f0cf148ae5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e61f994-45f4-4ee6-8b13-91108264cd40"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""AccelerateBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb38de1a-72b2-4bcf-996d-1bc27eb7d1a4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e4b73c-6417-459e-98c9-ec3a8f3ea047"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""822f589b-e6ed-43a5-bb34-cef298a9a070"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1d401800-bf36-419f-8945-2f3c9b5029bc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""76b30de6-9a41-45bf-b559-b0e4c29202c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8e1e297f-fe22-41bd-82d7-27e5a5655eaa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5163cc42-807a-4ab6-9e44-297466d0a824"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b95be4b5-11a4-48b0-8d06-dbf5e310965f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b913e5f0-7f40-4db8-a6a2-99723a2bab13"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""dc02c2b7-15ce-4862-bb93-d4ccfb59280e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AccelerateFront"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a78fe332-c589-4016-8b54-fbc306fb48cb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""AccelerateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c9c8c0a-ccd3-4c35-8d0e-24f4e9eb5f49"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b85a32e-83e3-400a-b572-6b420bc85d8e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard + Mouse"",
            ""bindingGroup"": ""Keyboard + Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Move = m_General.FindAction("Move", throwIfNotFound: true);
        m_General_Aim = m_General.FindAction("Aim", throwIfNotFound: true);
        m_General_Shoot = m_General.FindAction("Shoot", throwIfNotFound: true);
        m_General_AccelerateFront = m_General.FindAction("AccelerateFront", throwIfNotFound: true);
        m_General_AccelerateBack = m_General.FindAction("AccelerateBack", throwIfNotFound: true);
        m_General_HandBrake = m_General.FindAction("HandBrake", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Move;
    private readonly InputAction m_General_Aim;
    private readonly InputAction m_General_Shoot;
    private readonly InputAction m_General_AccelerateFront;
    private readonly InputAction m_General_AccelerateBack;
    private readonly InputAction m_General_HandBrake;
    public struct GeneralActions
    {
        private @TankKeyMap m_Wrapper;
        public GeneralActions(@TankKeyMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_General_Move;
        public InputAction @Aim => m_Wrapper.m_General_Aim;
        public InputAction @Shoot => m_Wrapper.m_General_Shoot;
        public InputAction @AccelerateFront => m_Wrapper.m_General_AccelerateFront;
        public InputAction @AccelerateBack => m_Wrapper.m_General_AccelerateBack;
        public InputAction @HandBrake => m_Wrapper.m_General_HandBrake;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnShoot;
                @AccelerateFront.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateFront;
                @AccelerateFront.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateFront;
                @AccelerateFront.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateFront;
                @AccelerateBack.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateBack;
                @AccelerateBack.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateBack;
                @AccelerateBack.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAccelerateBack;
                @HandBrake.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHandBrake;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AccelerateFront.started += instance.OnAccelerateFront;
                @AccelerateFront.performed += instance.OnAccelerateFront;
                @AccelerateFront.canceled += instance.OnAccelerateFront;
                @AccelerateBack.started += instance.OnAccelerateBack;
                @AccelerateBack.performed += instance.OnAccelerateBack;
                @AccelerateBack.canceled += instance.OnAccelerateBack;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IGeneralActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAccelerateFront(InputAction.CallbackContext context);
        void OnAccelerateBack(InputAction.CallbackContext context);
        void OnHandBrake(InputAction.CallbackContext context);
    }
}
