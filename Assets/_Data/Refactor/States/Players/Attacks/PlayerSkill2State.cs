using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using VyesBase.Core.StateMachine;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerSkill2State : BasePlayerState
    {
        private readonly BasePlayerSkillSoRuntime skillSoRuntime;

        public PlayerSkill2State(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillSoRuntime = playerController.Skill2Runtime;
        }

        public override void OnEnter()
        {
            eventController.OnEventEnd += EventEnd;

            if (skillSoRuntime.TryUse())
            {
                Attack();
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
            animator.SetTrigger(nameof(PlayerAnimParam.Skill2));
        }

        private void EventEnd()
        {
            stateMachine.ChangeState(PlayerState.NormalAttack);
        }
    }
}