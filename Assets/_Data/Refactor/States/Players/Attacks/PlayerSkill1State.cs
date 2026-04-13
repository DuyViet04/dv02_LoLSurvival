using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using VyesBase.Core.StateMachine;
using VyesBase.Utils.GameLogger;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerSkill1State : BasePlayerState
    {
        private readonly BasePlayerSkillSoRuntime skillSoRuntime;

        public PlayerSkill1State(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillSoRuntime = playerController.Skill1Runtime;
        }

        public override void OnEnter()
        {
            eventController.OnEventEnd += EventEnd;

            if (skillSoRuntime.TryUse())
            {
                Attack();
                // GameLogger.Log("Skill1");
            }
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            eventController.OnEventEnd -= EventEnd;
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.Skill1));
        }

        void EventEnd()
        {
            stateMachine.ChangeState(PlayerState.NormalAttack);
        }
    }
}