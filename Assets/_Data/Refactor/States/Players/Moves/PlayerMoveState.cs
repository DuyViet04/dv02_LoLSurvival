using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using Base.Core.StateMachine;
using Base.Systems.Input;
using UnityEngine;

namespace _Data.Refactor.States.Players.Moves
{
    public class PlayerMoveState : BasePlayerState
    {
        public PlayerMoveState(PlayerController playerController, StateMachine<PlayerState> stateMachine) : base(
            playerController, stateMachine)
        {
        }

        public override void OnEnter()
        {
            // GameLogger.Log("Enter move state");
            animator.SetFloat(nameof(PlayerAnimParam.MoveSpeed), 1);
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
            var moveInput = InputManager.Ins.Move;

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

            var moveSpeed = runtime.UtilityData.MoveSpeed;
            rigidbody.linearVelocity = moveDir * moveSpeed;
        }
    }
}