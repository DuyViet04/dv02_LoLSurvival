using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Models.Runtimes.Enemies;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Enemies
{
    public abstract class BaseEnemyState : IState
    {
        protected StateMachine<EnemyState> stateMachine;
        protected readonly Rigidbody rigidbody;
        protected readonly Transform target;
        protected readonly Transform self;
        protected readonly BulletSpawner bulletSpawner;
        protected readonly BaseEnemyRuntime runtime;

        protected BaseEnemyState(EnemyController controller, StateMachine<EnemyState> stateMachine)
        {
            this.stateMachine = stateMachine;
            rigidbody = controller.Rigidbody;
            target = controller.Target;
            self = controller.transform;
            bulletSpawner = controller.BulletSpawner;
            runtime = controller.BaseEnemyRuntime;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnExit();
    }
}