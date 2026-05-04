using _Data.Refactor.Controllers.Bosses;
using _Data.Refactor.Enums.Bosses;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Bosses.Attacks
{
    public class BossIdleState : BaseBossState
    {
        public BossIdleState(BossController controller, StateMachine<BossState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(self.position, target.position) < 5f)
            {
                stateMachine.ChangeState(BossState.Skill);
            }
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}