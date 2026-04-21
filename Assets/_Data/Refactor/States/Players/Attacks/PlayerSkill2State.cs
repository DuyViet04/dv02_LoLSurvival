using System.Linq;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.StateMachine;
using Base.Systems.Animation;
using Base.Systems.Skill;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerSkill2State : BasePlayerState
    {
        private BasePlayerSkillRuntime skillRuntime;

        public PlayerSkill2State(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
        }

        public override void OnEnter()
        {
            eventController.OnEvent += OnEventTrigger;

            skillRuntime = skillsRuntime.FirstOrDefault(s => s.SkillData.SkillType == SkillType.Skill2);
            if (skillRuntime!.TryUseSkill())
            {
                Attack();
            }
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit()
        {
            eventController.OnEvent -= OnEventTrigger;
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.Skill2));
        }

        private void OnEventTrigger(EventType eventType)
        {
            stateMachine.ChangeState(PlayerState.NormalAttack);
        }
    }
}