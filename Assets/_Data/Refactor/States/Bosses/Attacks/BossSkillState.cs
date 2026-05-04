using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Enums.Bosses;
using _Data.Refactor.Enums;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Bosses.Attacks
{
    public class BossSkillState : BaseBossState
    {
        private float cooldownTimer;
        private bool isExecuting;

        public BossSkillState(BossController controller, StateMachine<BossState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
            ExecuteSkill();
        }

        public override void OnUpdate()
        {
            CheckSkillExecution();
            UpdateCooldown();

            if (!isExecuting && cooldownTimer <= 0)
            {
                if (Vector3.Distance(self.position, target.position) < 5f)
                {
                    ExecuteSkill();
                }
                else
                {
                    stateMachine.ChangeState(BossState.Idle);
                }
            }
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit()
        {
            controller.Animator.ResetTrigger(nameof(AnimationParams.IsAttack));
        }

        void ExecuteSkill()
        {
            controller.Animator.SetTrigger(nameof(AnimationParams.IsAttack));
            isExecuting = true;
            cooldownTimer = 2f;
        }

        void CheckSkillExecution()
        {
            AnimatorStateInfo stateInfo = controller.Animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Q1") || stateInfo.IsName("Q2") || stateInfo.IsName("Q3"))
            {
                isExecuting = true;
            }
            else
            {
                isExecuting = false;
            }
        }

        void UpdateCooldown()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
        }
    }
}