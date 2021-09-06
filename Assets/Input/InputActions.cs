// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""299c32bb-e17d-498f-a223-0128426d2695"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""20685a93-3e7f-4ce7-ac42-ae4edd52be30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""da00a142-b34e-4d82-8577-f76f8bd51289"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""62468c72-55d9-493d-a70d-6b284424fc68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""c6ccfa53-90e7-47fe-9e29-9f5b640cc38c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""61dc6a3a-4582-4b65-8ae3-7240ad47ff63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock"",
                    ""type"": ""Button"",
                    ""id"": ""b53a62e9-adf2-4fb8-b1b5-ec0105bc7612"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Wheel"",
                    ""type"": ""Value"",
                    ""id"": ""eaa48525-7522-47b2-a6f9-a4325a3c7447"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleAxis"",
                    ""type"": ""Button"",
                    ""id"": ""713c5f47-929a-4f00-b943-0f4ede8643c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf4a14c2-125f-4116-8bea-9080db4fa3d7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31b997a8-5faf-444a-9f40-c6eaad69ff23"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d380134-40c5-42c9-8902-522f508aa193"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""299d1f5a-f7a3-4ca9-a2c8-11b8d5a2059b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753bc8b2-5d8c-41cb-acd3-67a790d85bb0"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c64cfd0-37a1-47e1-b312-68355c4e4b0f"",
                    ""path"": ""<Keyboard>/#(L)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Lock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a66c892-b584-4a09-9fe1-65b295899cff"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7311cdae-b5b8-4a56-97b7-6afdc53f82aa"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""ToggleAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Position = m_Player.FindAction("Position", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_Delta = m_Player.FindAction("Delta", throwIfNotFound: true);
        m_Player_Reset = m_Player.FindAction("Reset", throwIfNotFound: true);
        m_Player_Lock = m_Player.FindAction("Lock", throwIfNotFound: true);
        m_Player_Wheel = m_Player.FindAction("Wheel", throwIfNotFound: true);
        m_Player_ToggleAxis = m_Player.FindAction("ToggleAxis", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Position;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_Delta;
    private readonly InputAction m_Player_Reset;
    private readonly InputAction m_Player_Lock;
    private readonly InputAction m_Player_Wheel;
    private readonly InputAction m_Player_ToggleAxis;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Position => m_Wrapper.m_Player_Position;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @Delta => m_Wrapper.m_Player_Delta;
        public InputAction @Reset => m_Wrapper.m_Player_Reset;
        public InputAction @Lock => m_Wrapper.m_Player_Lock;
        public InputAction @Wheel => m_Wrapper.m_Player_Wheel;
        public InputAction @ToggleAxis => m_Wrapper.m_Player_ToggleAxis;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Position.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Delta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelta;
                @Reset.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReset;
                @Lock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Lock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Lock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Wheel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
                @Wheel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
                @Wheel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWheel;
                @ToggleAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleAxis;
                @ToggleAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleAxis;
                @ToggleAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleAxis;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @Lock.started += instance.OnLock;
                @Lock.performed += instance.OnLock;
                @Lock.canceled += instance.OnLock;
                @Wheel.started += instance.OnWheel;
                @Wheel.performed += instance.OnWheel;
                @Wheel.canceled += instance.OnWheel;
                @ToggleAxis.started += instance.OnToggleAxis;
                @ToggleAxis.performed += instance.OnToggleAxis;
                @ToggleAxis.canceled += instance.OnToggleAxis;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnLock(InputAction.CallbackContext context);
        void OnWheel(InputAction.CallbackContext context);
        void OnToggleAxis(InputAction.CallbackContext context);
    }
}
