using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Controllers.Spawners;
using Base.Core.StateMachine;

namespace _Data.Refactor.States.Enemies.Moves
{
    public class EnemyDieState : BaseEnemyState

    {
        public EnemyDieState(EnemyController controller, StateMachine<EnemyState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
            expSpawner.Spawn(nameof(ExpType.Exp), self.position, self.rotation);
            enemySpawner.Despawn(self);
            enemySpawner.EnemyCount--;
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}