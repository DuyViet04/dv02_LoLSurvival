using System.Linq;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.StateMachine;
using Base.Systems.Skill;
using EventType = Base.Systems.Animation.EventType;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerSkill1State : BasePlayerState
    {
        private readonly BasePlayerSkillRuntime skillRuntime;

        public PlayerSkill1State(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillRuntime = skillsRuntime.FirstOrDefault(s => s.SkillData.SkillType == SkillType.Skill1);
        }

        public override void OnEnter()
        {
            eventController.OnEvent += OnEventTrigger;
            eventController.OnEvent += TriggerWeaponCollider;

            attackData.SetAttackData(
                skillRuntime.GetDamage(runtime.CurrentAttackDamage, runtime.OffensiveData.AbilityPower.Value),
                skillRuntime.SkillData.CanCrit,
                runtime.OffensiveData.CritDamage.Value, skillRuntime.SkillData.DamageType);
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
            eventController.OnEvent -= TriggerWeaponCollider;
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.Skill1));
            vfxSpawner.Spawn(nameof(VFXType.YasuoSkill1), self.position, self.rotation);
        }

        void OnEventTrigger(EventType eventType)
        {
            stateMachine.ChangeState(PlayerState.NormalAttack);
        }
    }
}