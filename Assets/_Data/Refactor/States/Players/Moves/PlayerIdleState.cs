using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using UnityEngine;
using VyesBase.Core.StateMachine;
using VyesBase.Systems.Input;
using VyesBase.Utils.GameLogger;

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
            var moveInput = InputManager.Instance.MoveInput;
            if (moveInput != Vector2.zero)
            {
                stateMachine.ChangeState(PlayerState.Move);
            }
        }

        public override void OnExit()
        {
        }
    }
}