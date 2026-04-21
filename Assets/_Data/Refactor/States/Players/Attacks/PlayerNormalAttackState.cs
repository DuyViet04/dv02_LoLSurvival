using System.Linq;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.StateMachine;
using Base.Systems.Skill;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerNormalAttackState : BasePlayerState
    {
        private BasePlayerSkillRuntime skillRuntime;

        public PlayerNormalAttackState(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
        }

        public override void OnEnter()
        {
            skillRuntime = skillsRuntime.FirstOrDefault(s => s.SkillData.SkillType == SkillType.Normal);
            // GameLogger.Log("Enter normal attack state");
            // GameLogger.Log($"{runtime.CurrentCooldown}");
        }

        public override void OnUpdate()
        {
            if (skillRuntime.TryUseSkill())
            {
                Attack();
            }
        }

        public override void OnFixedUpdate()
        {
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