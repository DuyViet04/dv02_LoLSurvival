using System;
using UnityEngine;
using VyesBase.Core.Singleton;

namespace VyesBase.Systems.Input
{
    public class InputManager : VyesPersistentSingleton<InputManager>, IInputProvider
    {
        private VyesBaseInput _inputActions;

        public Vector2 MoveInput => _inputActions.Player.Move.ReadValue<Vector2>();
        public Vector2 MousePosition => _inputActions.Player.Look.ReadValue<Vector2>();
        public bool Jump => _inputActions.Player.Jump.IsPressed();
        public bool Attack => _inputActions.Player.Attack.IsPressed();

        public Vector2 UINavigate => _inputActions.UI.Navigate.ReadValue<Vector2>();
        public bool UISubmit => _inputActions.UI.Submit.IsPressed();

        public event Action OnJumpPressed;
        public event Action OnAttackPressed;

        protected override void Awake()
        {
            base.Awake();
            _inputActions = new VyesBaseInput();

            _inputActions.Player.Jump.performed += ctx => OnJumpPressed?.Invoke();
            _inputActions.Player.Attack.performed += ctx => OnAttackPressed?.Invoke();

            TogglePlayerInput(true);
            ToggleUIInput(false);
        }

        public void TogglePlayerInput(bool enabled)
        {
            if (enabled) _inputActions.Player.Enable();
            else _inputActions.Player.Disable();
        }

        public void ToggleUIInput(bool enabled)
        {
            if (enabled) _inputActions.UI.Enable();
            else _inputActions.UI.Disable();
        }

        private void OnDisable()
        {
            _inputActions?.Disable();
        }
    }
}
