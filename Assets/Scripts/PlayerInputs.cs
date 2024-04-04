//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Direction"",
            ""id"": ""f689b150-a4a2-48f2-9d7c-96f067f5e8ca"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""642278cc-4846-4ad0-9280-5175aca0cc1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""60615926-6225-4d24-8cad-f6fdeae40afd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""ee44048d-37c6-4979-a496-f4e4939ec954"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""ae56b0b3-9b85-49ec-84a5-98add92296df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebcf8781-24a7-4331-92ec-9f61b5436d44"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af097e78-7d78-4be0-8f64-5af4e829d990"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33f8c2e8-1344-44ac-885b-f1d5d35f9561"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b002d1f-f70d-4085-895a-a79586ea8d85"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Direction
        m_Direction = asset.FindActionMap("Direction", throwIfNotFound: true);
        m_Direction_Up = m_Direction.FindAction("Up", throwIfNotFound: true);
        m_Direction_Down = m_Direction.FindAction("Down", throwIfNotFound: true);
        m_Direction_Left = m_Direction.FindAction("Left", throwIfNotFound: true);
        m_Direction_Right = m_Direction.FindAction("Right", throwIfNotFound: true);
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

    // Direction
    private readonly InputActionMap m_Direction;
    private IDirectionActions m_DirectionActionsCallbackInterface;
    private readonly InputAction m_Direction_Up;
    private readonly InputAction m_Direction_Down;
    private readonly InputAction m_Direction_Left;
    private readonly InputAction m_Direction_Right;
    public struct DirectionActions
    {
        private @PlayerInputs m_Wrapper;
        public DirectionActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Direction_Up;
        public InputAction @Down => m_Wrapper.m_Direction_Down;
        public InputAction @Left => m_Wrapper.m_Direction_Left;
        public InputAction @Right => m_Wrapper.m_Direction_Right;
        public InputActionMap Get() { return m_Wrapper.m_Direction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DirectionActions set) { return set.Get(); }
        public void SetCallbacks(IDirectionActions instance)
        {
            if (m_Wrapper.m_DirectionActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_DirectionActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_DirectionActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_DirectionActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_DirectionActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_DirectionActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_DirectionActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_DirectionActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_DirectionActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_DirectionActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_DirectionActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_DirectionActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_DirectionActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_DirectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public DirectionActions @Direction => new DirectionActions(this);
    public interface IDirectionActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
