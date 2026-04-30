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
        private readonly BasePlayerSkillRuntime skillRuntime;

        public PlayerNormalAttackState(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillRuntime = skillsRuntime.FirstOrDefault(s => s.SkillData.SkillType == SkillType.Normal);
        }

        public override void OnEnter()
        {
            eventController.OnEvent += TriggerWeaponCollider;
            attackData.SetPenetration(runtime.OffensiveData.ArmorPenetration.Value,
                runtime.OffensiveData.ArmorPenetrationPercent.Value,
                runtime.OffensiveData.MagicPenetration.Value,
                runtime.OffensiveData.MagicPenetrationPercent.Value);
            attackData.SetAttackData(
                skillRuntime.GetDamage(runtime.CurrentAttackDamage, runtime.OffensiveData.AbilityPower.Value),
                skillRuntime.SkillData.CanCrit,
                runtime.OffensiveData.CritDamage.Value, skillRuntime.SkillData.DamageType, skillRuntime.SkillData.SkillType);
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
            eventController.OnEvent -= TriggerWeaponCollider;
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.NormalAttack));
        }
    }
}