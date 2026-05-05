using _Data.Refactor.Controllers.Bosses;
using _Data.Refactor.Enums.Bosses;
using _Data.Refactor.Models.Runtimes.Bosses;
using Base.Core.StateMachine;
using UnityEngine;

namespace _Data.Refactor.States.Bosses
{
    public abstract class BaseBossState : IState
    {
        protected readonly StateMachine<BossState> stateMachine;
        protected readonly BossController controller;
        protected readonly Rigidbody rigidbody;
        protected readonly Transform target;
        protected readonly Transform self;
        protected BaseBossRuntime runtime => controller.BossRuntime;

        protected BaseBossState(BossController controller, StateMachine<BossState> stateMachine)
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