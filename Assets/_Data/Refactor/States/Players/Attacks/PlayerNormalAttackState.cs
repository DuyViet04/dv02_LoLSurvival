using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using VyesBase.Core.StateMachine;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerNormalAttackState : BasePlayerState
    {
        private readonly BasePlayerSkillSoRuntime skillSoRuntime;

        public PlayerNormalAttackState(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillSoRuntime = playerController.NormalAttackRuntime;
        }

        public override void OnEnter()
        {
            // GameLogger.Log("Enter normal attack state");
            // GameLogger.Log($"{runtime.CurrentCooldown}");
        }

        public override void OnUpdate()
        {
            if (skillSoRuntime.TryUse())
            {
                Attack();
            }
        }

        public override void OnExit()
        {
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.NormalAttack));
        }
    }
}