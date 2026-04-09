using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using UnityEngine;
using VyesBase.Core.StateMachine;
using VyesBase.Systems.Input;
using VyesBase.Utils.GameLogger;

namespace _Data.Refactor.States.Players
{
    public class PlayerMoveState : BasePlayerState
    {
        public PlayerMoveState(PlayerController playerController, StateMachine<PlayerState> stateMachine) : base(
            playerController, stateMachine)
        {
        }

        public override void OnEnter()
        {
            GameLogger.Log("Enter move state");
            animator.SetFloat(nameof(PlayerAnimParam.MoveSpeed), 1);
        }

        public override void OnUpdate()
        {
            var moveInput = InputManager.Instance.MoveInput;
            
            Move(moveInput);
            
            if (moveInput.magnitude < 0.1f)
            {
                stateMachine.ChangeState(PlayerState.Idle);
            }
        }

        public override void OnExit()
        {
        }

        void Move(Vector2 moveInput)
        {
            Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            var moveSpeed = runtime.MoveSpeed;
            rigidbody.linearVelocity = moveDir * moveSpeed;
        }
    }
}