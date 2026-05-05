using _Data.Refactor.Controllers.Bosses;
using _Data.Refactor.Enums.Bosses;
using _Data.Refactor.Enums;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Bosses.Moves
{
    public class BossChaseState : BaseBossState
    {
        public BossChaseState(BossController controller, StateMachine<BossState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
            if (controller.AttackStateMachine.CurrentStateKey == BossState.Skill)
            {
                StopMoving();
                return;
            }

            MoveToTarget();
        }

        public override void OnExit()
        {
        }

        void MoveToTarget()
        {
            var moveSpeed = runtime.UtilityData.MoveSpeed.Value;
            var dir = (target.position - self.position).normalized;
            self.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            rigidbody.linearVelocity = moveSpeed * new Vector3(dir.x, 0, dir.z);
            controller.Animator.SetFloat(nameof(AnimationParams.MovingSpeed), moveSpeed);
        }

        void StopMoving()
        {
            rigidbody.linearVelocity = Vector3.zero;
            controller.Animator.SetFloat(nameof(AnimationParams.MovingSpeed), 0);
        }
    }
}