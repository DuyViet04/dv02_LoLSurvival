using System.Collections;
using System.Linq;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.StateMachine;
using Base.Systems.Skill;
using Base.Systems.Sound;
using UnityEngine;
using EventType = Base.Systems.Animation.EventType;

namespace _Data.Refactor.States.Players.Attacks
{
    public class PlayerSkill2State : BasePlayerState
    {
        private readonly BasePlayerSkillRuntime skillRuntime;
        private Coroutine dashCoroutine;
        private readonly float dashDuration = 0.5f;
        private readonly float dashSpeed = 10f;
        private bool isDashing;

        public PlayerSkill2State(PlayerController playerController, StateMachine<PlayerState> stateMachine) :
            base(playerController, stateMachine)
        {
            skillRuntime = skillsRuntime.FirstOrDefault(s => s.SkillData.SkillType == SkillType.Skill2);
        }

        public override void OnEnter()
        {
            eventController.OnEvent += OnEventTrigger;
            eventController.OnEvent += TriggerWeaponCollider;

            if (isDashing) return;

            attackData.SetPenetration(runtime.OffensiveData.ArmorPenetration.Value,
                runtime.OffensiveData.ArmorPenetrationPercent.Value,
                runtime.OffensiveData.MagicPenetration.Value,
                runtime.OffensiveData.MagicPenetrationPercent.Value);
            attackData.SetAttackData(
                skillRuntime.GetDamage(runtime.CurrentAttackDamage, runtime.OffensiveData.AbilityPower.Value),
                skillRuntime.SkillData.CanCrit,
                runtime.OffensiveData.CritDamage.Value, skillRuntime.SkillData.DamageType,
                skillRuntime.SkillData.SkillType);
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
            if (isDashing)
            {
                rigidbody.linearVelocity = self.forward * dashSpeed;
            }
        }

        public override void OnExit()
        {
            eventController.OnEvent -= OnEventTrigger;
            eventController.OnEvent -= TriggerWeaponCollider;
        }

        void Attack()
        {
            animator.SetTrigger(nameof(PlayerAnimParam.Skill2));
            dashCoroutine = playerController.StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            isDashing = true;
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
            rigidbody.linearVelocity = Vector3.zero;
            dashCoroutine = null;
        }

        private void OnEventTrigger(EventType eventType)
        {
            stateMachine.ChangeState(PlayerState.NormalAttack);
        }
    }
}