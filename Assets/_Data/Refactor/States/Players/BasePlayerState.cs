using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.SOs.Players;
using UnityEngine;
using VyesBase.Core.StateMachine;
using VyesBase.Systems.Skills;

namespace _Data.Refactor.States.Players
{
    public abstract class BasePlayerState : IState
    {
        protected readonly PlayerController playerController;
        protected readonly StateMachine<PlayerState> stateMachine;
        protected readonly Animator animator;
        protected readonly Rigidbody rigidbody;
        protected readonly Camera mainCamera;
        protected readonly Transform self;
        protected readonly BasePlayerSo so;
        protected readonly List<BaseSkillSo> skills;

        protected readonly BasePlayerSoRuntime runtime;

        protected BasePlayerState(PlayerController playerController, StateMachine<PlayerState> stateMachine)
        {
            this.playerController = playerController;
            this.stateMachine = stateMachine;
            animator = playerController.Animator;
            mainCamera = playerController.MainCamera;
            self = playerController.transform;
            rigidbody = playerController.Rigidbody;
            so = playerController.BasePlayerSo;
            skills = so.skills;

            runtime = (BasePlayerSoRuntime)so.CreateRuntime();
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}