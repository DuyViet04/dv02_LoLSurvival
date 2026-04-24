using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Controllers.Spawners;
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
        protected readonly PlayerController playerController;
        protected readonly StateMachine<PlayerState> stateMachine;
        protected readonly Animator animator;
        protected readonly Rigidbody rigidbody;
        protected readonly AnimationController eventController;
        protected readonly Collider weaponCollider;
        protected readonly BasePlayerRuntime runtime;
        protected readonly List<BasePlayerSkillRuntime> skillsRuntime;
        protected readonly VfxSpawner vfxSpawner;
        protected readonly Transform self;

        protected BasePlayerState(PlayerController playerController, StateMachine<PlayerState> stateMachine)
        {
            this.playerController = playerController;
            this.stateMachine = stateMachine;
            animator = playerController.Animator;
            rigidbody = playerController.Rigidbody;
            eventController = playerController.AnimationController;
            weaponCollider = playerController.WeaponCollider;
            runtime = playerController.CharacterRuntime;
            skillsRuntime = playerController.SkillsRuntime;
            vfxSpawner = playerController.VfxSpawner;
            self = playerController.transform;
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