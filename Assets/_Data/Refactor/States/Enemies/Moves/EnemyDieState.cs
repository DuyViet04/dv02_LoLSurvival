using _Data.Refactor.Controllers;
using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Controllers.Spawners;
using Base.Core.StateMachine;
using Base.Systems.Sound;

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
            SoundManager.Ins.PlaySfx("GetGold");
            var exp = expSpawner.Spawn(nameof(ExpType.Exp), self.position, self.rotation);
            exp.gameObject.GetComponent<ExpController>().SetExpValue(runtime.EnemyData.ExpValue.Value);
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