using _Data.Refactor.Controllers.Enemies;
using UnityEngine;
using VyesBase.Core.StateMachine;

namespace _Data.Refactor.States.Enemies.Moves
{
    public class EnemyChaseState : BaseEnemyState
    {
        public EnemyChaseState(EnemyController controller, StateMachine<EnemyState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        void MoveToTarget(Transform target, float moveSpeed)
        {
            var dir = (target.position - rigidbody.position).normalized;
            var dir2D = new Vector2(dir.x, dir.z).normalized;
            rigidbody.linearVelocity = moveSpeed * dir2D;
        }
    }
}