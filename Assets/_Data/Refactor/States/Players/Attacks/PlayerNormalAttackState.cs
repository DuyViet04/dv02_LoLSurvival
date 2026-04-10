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
    public class PlayerNormalAttackState : BasePlayerState
    {
        private readonly BasePlayerSkillSoRuntime skillSoRuntime;

        public PlayerNormalAttackState(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillSoRuntime = (BasePlayerSkillSoRuntime)skills
                .Find(s => ((BasePlayerSkillSo)s).skillType == SkillType.NormalAttack).CreateRuntime();
        }

        public override void OnEnter()
        {
            // GameLogger.Log("Enter normal attack state");
            // GameLogger.Log($"{runtime.CurrentCooldown}");
        }

        public override void OnUpdate()
        {
            skillSoRuntime.UpdateCooldown(Time.deltaTime);
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