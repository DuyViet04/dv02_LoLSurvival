using _Data.Refactor.Controllers.Enemies;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Enemies
{
    public abstract class BaseEnemyState : IState
    {
        protected EnemyController controller;
        protected StateMachine<EnemyState> stateMachine;

        protected readonly Rigidbody rigidbody;
        protected readonly Transform target;
        protected readonly Transform self;

        protected BaseEnemyState(EnemyController controller, StateMachine<EnemyState> stateMachine)
        {
            this.controller = controller;
            this.stateMachine = stateMachine;
            rigidbody = controller.Rigidbody;
            target = controller.Target;
            self = controller.transform;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnExit();
    }
}