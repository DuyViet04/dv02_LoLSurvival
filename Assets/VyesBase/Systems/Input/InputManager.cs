using System;
using UnityEngine;
using VyesBase.Core.Singleton;

namespace VyesBase.Systems.Input
{
    public class InputManager : VyesPersistentSingleton<InputManager>, IInputProvider
    {
        private VyesBaseInput inputActions;

        public Vector2 MoveInput => inputActions.Player.Move.ReadValue<Vector2>();
        public Vector2 MousePosition => inputActions.Player.Look.ReadValue<Vector2>();
        public bool Jump => inputActions.Player.Jump.IsPressed();
        public bool Attack => inputActions.Player.Attack.IsPressed();
        public bool Attack2 => inputActions.Player.Attack2.IsPressed();

        public Vector2 UINavigate => inputActions.UI.Navigate.ReadValue<Vector2>();
        public bool UISubmit => inputActions.UI.Submit.IsPressed();

        public event Action OnJumpPressed;
        public event Action OnAttackPressed;

        protected override void Awake()
        {
            base.Awake();
            inputActions = new VyesBaseInput();

            inputActions.Player.Jump.performed += ctx => OnJumpPressed?.Invoke();
            inputActions.Player.Attack.performed += ctx => OnAttackPressed?.Invoke();

            TogglePlayerInput(true);
            ToggleUIInput(false);
        }

        public void TogglePlayerInput(bool enabled)
        {
            if (enabled) inputActions.Player.Enable();
            else inputActions.Player.Disable();
        }

        public void ToggleUIInput(bool enabled)
        {
            if (enabled) inputActions.UI.Enable();
            else inputActions.UI.Disable();
        }

        private void OnDisable()
        {
            inputActions?.Disable();
        }
    }
}