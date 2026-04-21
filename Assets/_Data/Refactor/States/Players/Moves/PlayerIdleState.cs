using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using Base.Core.StateMachine;
using Base.Systems.Input;
using UnityEngine;

namespace _Data.Refactor.States.Players.Moves
{
    public class PlayerIdleState : BasePlayerState
    {
        public PlayerIdleState(PlayerController playerController, StateMachine<PlayerState> stateMachine) : base(
            playerController, stateMachine)
        {
        }

        public override void OnEnter()
        {
            // GameLogger.Log("Enter idle state");
            animator.SetFloat(nameof(PlayerAnimParam.MoveSpeed), 0);
        }

        public override void OnUpdate()
        {
            var moveInput = InputManager.Ins.Move;
            if (moveInput != Vector2.zero)
            {
                stateMachine.ChangeState(PlayerState.Move);
            }
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}