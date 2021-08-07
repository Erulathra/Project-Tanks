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
                    ""id"": ""82fd8c5e-a94c-47aa-b88c-6a28ec1ed7cc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64e26a8a-5360-4859-9c98-1a470a9edcc5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbf6fac4-e864-4735-ba16-efdc1d574dcd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee1363d7-255a-4aad-8715-65f20be06001"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AccelerateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e61f994-45f4-4ee6-8b13-91108264cd40"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AccelerateBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e4b73c-6417-459e-98c9-ec3a8f3ea047"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
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
