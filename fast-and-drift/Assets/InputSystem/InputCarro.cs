//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/InputCarro.inputactions
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

public partial class @InputCarro: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputCarro()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputCarro"",
    ""maps"": [
        {
            ""name"": ""Carro"",
            ""id"": ""aee9713c-1d1a-48b5-827b-01522e706237"",
            ""actions"": [
                {
                    ""name"": ""Acelerar/Ré"",
                    ""type"": ""Value"",
                    ""id"": ""f059a6e0-ad11-40b8-be9a-607c984ab231"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotacionar"",
                    ""type"": ""Value"",
                    ""id"": ""fdb723c7-6672-478e-a870-688df020bd8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Freiar"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5911450d-ccad-4fc4-91df-3e4a2d93a911"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Nitro"",
                    ""type"": ""Value"",
                    ""id"": ""46409271-e79b-4131-8515-6cbbf225722b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""c99e9248-6af6-41a5-af10-f1d2f3e67e31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Teclado"",
                    ""id"": ""bbccf64b-2cb0-46ea-9a0f-c3fbec2e76d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acelerar/Ré"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""93261431-aa19-42a3-b571-fd8ec0d438fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acelerar/Ré"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc3694e7-a9fd-4761-8356-320d9e01d00e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acelerar/Ré"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado"",
                    ""id"": ""62d75f13-3fed-4d0f-ad19-0b3007c25bf7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0694707b-1efd-4526-83ad-279a23001dbc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3dff82f7-f473-4057-b943-f1bfe61049ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mobile"",
                    ""id"": ""35d320c8-eeec-46e8-b2ff-25d9d431ed49"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""17c46aaf-fb87-42ec-b773-0c5fd418a82c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""73a29ede-f26c-48d2-b3f7-e1a09f769cee"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotacionar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""27e610ae-57de-41b4-99bc-10c240557d54"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Freiar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c166d493-5f5e-428e-909e-12c8aa47ec28"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Freiar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9cd5a4b-9279-4d04-8751-c0071b6b588e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nitro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d312c424-e682-4058-983b-21dbd3d69841"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nitro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b50d495-6a51-498e-a0e7-118ddc0e3cea"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eefab8bb-d313-4d4a-bd74-f90bf2e20c0a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Carro
        m_Carro = asset.FindActionMap("Carro", throwIfNotFound: true);
        m_Carro_AcelerarRé = m_Carro.FindAction("Acelerar/Ré", throwIfNotFound: true);
        m_Carro_Rotacionar = m_Carro.FindAction("Rotacionar", throwIfNotFound: true);
        m_Carro_Freiar = m_Carro.FindAction("Freiar", throwIfNotFound: true);
        m_Carro_Nitro = m_Carro.FindAction("Nitro", throwIfNotFound: true);
        m_Carro_Pause = m_Carro.FindAction("Pause", throwIfNotFound: true);
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

    // Carro
    private readonly InputActionMap m_Carro;
    private List<ICarroActions> m_CarroActionsCallbackInterfaces = new List<ICarroActions>();
    private readonly InputAction m_Carro_AcelerarRé;
    private readonly InputAction m_Carro_Rotacionar;
    private readonly InputAction m_Carro_Freiar;
    private readonly InputAction m_Carro_Nitro;
    private readonly InputAction m_Carro_Pause;
    public struct CarroActions
    {
        private @InputCarro m_Wrapper;
        public CarroActions(@InputCarro wrapper) { m_Wrapper = wrapper; }
        public InputAction @AcelerarRé => m_Wrapper.m_Carro_AcelerarRé;
        public InputAction @Rotacionar => m_Wrapper.m_Carro_Rotacionar;
        public InputAction @Freiar => m_Wrapper.m_Carro_Freiar;
        public InputAction @Nitro => m_Wrapper.m_Carro_Nitro;
        public InputAction @Pause => m_Wrapper.m_Carro_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Carro; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarroActions set) { return set.Get(); }
        public void AddCallbacks(ICarroActions instance)
        {
            if (instance == null || m_Wrapper.m_CarroActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CarroActionsCallbackInterfaces.Add(instance);
            @AcelerarRé.started += instance.OnAcelerarRé;
            @AcelerarRé.performed += instance.OnAcelerarRé;
            @AcelerarRé.canceled += instance.OnAcelerarRé;
            @Rotacionar.started += instance.OnRotacionar;
            @Rotacionar.performed += instance.OnRotacionar;
            @Rotacionar.canceled += instance.OnRotacionar;
            @Freiar.started += instance.OnFreiar;
            @Freiar.performed += instance.OnFreiar;
            @Freiar.canceled += instance.OnFreiar;
            @Nitro.started += instance.OnNitro;
            @Nitro.performed += instance.OnNitro;
            @Nitro.canceled += instance.OnNitro;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(ICarroActions instance)
        {
            @AcelerarRé.started -= instance.OnAcelerarRé;
            @AcelerarRé.performed -= instance.OnAcelerarRé;
            @AcelerarRé.canceled -= instance.OnAcelerarRé;
            @Rotacionar.started -= instance.OnRotacionar;
            @Rotacionar.performed -= instance.OnRotacionar;
            @Rotacionar.canceled -= instance.OnRotacionar;
            @Freiar.started -= instance.OnFreiar;
            @Freiar.performed -= instance.OnFreiar;
            @Freiar.canceled -= instance.OnFreiar;
            @Nitro.started -= instance.OnNitro;
            @Nitro.performed -= instance.OnNitro;
            @Nitro.canceled -= instance.OnNitro;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(ICarroActions instance)
        {
            if (m_Wrapper.m_CarroActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICarroActions instance)
        {
            foreach (var item in m_Wrapper.m_CarroActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CarroActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CarroActions @Carro => new CarroActions(this);
    public interface ICarroActions
    {
        void OnAcelerarRé(InputAction.CallbackContext context);
        void OnRotacionar(InputAction.CallbackContext context);
        void OnFreiar(InputAction.CallbackContext context);
        void OnNitro(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
