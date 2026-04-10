using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Enums.Skills;
using _Data.Refactor.Models.Runtimes.Skills;
using _Data.Refactor.Models.SOs.Skills;
using UnityEngine;
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
            skillSoRuntime = (BasePlayerSkillSoRuntime)skills
                .Find(s => ((BasePlayerSkillSo)s).skillType == SkillType.Skill1).CreateRuntime();
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            skillSoRuntime.UpdateCooldown(Time.deltaTime);
            if (skillSoRuntime.TryUse())
            {
                Attack();
                GameLogger.Log("Skill1");
            }

            stateMachine.ChangeState(PlayerState.NormalAttack);
        }

        public override void OnExit()
        {
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.Skill1));
        }
    }
}