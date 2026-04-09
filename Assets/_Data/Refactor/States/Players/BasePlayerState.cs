using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.SOs.Players;
using UnityEngine;
using VyesBase.Core.StateMachine;

namespace _Data.Refactor.States.Players
{
    public abstract class BasePlayerState : IState
    {
        protected readonly PlayerController playerController;
        protected readonly StateMachine<PlayerState> stateMachine;
        protected readonly Animator animator;
        protected readonly Rigidbody rigidbody;
        protected readonly BasePlayerSo so;
        protected readonly BasePlayerSoRuntime runtime;
        
        protected BasePlayerState(PlayerController playerController, StateMachine<PlayerState> stateMachine)
        {
            this.playerController = playerController;
            this.stateMachine = stateMachine;
            animator = playerController.Animator;
            rigidbody = playerController.Rigidbody;
            so = playerController.BasePlayerSo;

            runtime = (BasePlayerSoRuntime)so.CreateRuntime();
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}