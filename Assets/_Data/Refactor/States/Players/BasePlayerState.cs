using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.StateMachine;
using Base.Systems.Animation;
using UnityEngine;
using EventType = Base.Systems.Animation.EventType;

namespace _Data.Refactor.States.Players
{
    public abstract class BasePlayerState : IState
    {
        protected readonly StateMachine<PlayerState> stateMachine;
        protected readonly Animator animator;
        protected readonly Rigidbody rigidbody;
        protected readonly AnimationController eventController;
        protected readonly Collider weaponCollider;
        protected readonly BasePlayerRuntime runtime;
        protected readonly List<BasePlayerSkillRuntime> skillsRuntime;

        protected BasePlayerState(PlayerController playerController, StateMachine<PlayerState> stateMachine)
        {
            this.stateMachine = stateMachine;
            animator = playerController.Animator;
            rigidbody = playerController.Rigidbody;
            eventController = playerController.AnimationController;
            weaponCollider = playerController.WeaponCollider;
            runtime = playerController.CharacterRuntime;
            skillsRuntime = playerController.SkillsRuntime;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnExit();

        protected void TriggerWeaponCollider(EventType eventType)
        {
            if (eventType == EventType.Start)
            {
                weaponCollider.enabled = true;
            }
            else if (eventType == EventType.End)
            {
                weaponCollider.enabled = false;
            }
        }
    }
}