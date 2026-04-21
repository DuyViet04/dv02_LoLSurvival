using System;
using System.Collections.Generic;
using _Data.Refactor.Enums.Players;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Services.LookAtMouse;
using _Data.Refactor.States.Players;
using _Data.Refactor.States.Players.Attacks;
using _Data.Refactor.States.Players.Moves;
using Base.Core.Architecture;
using Base.Systems.Animation;
using Base.Systems.Input;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    // Todo: Attack, Cooldown
    public class PlayerController : BaseController
    {
        [SerializeField] private Animator animator;
        public Animator Animator => animator;
        [SerializeField] private Rigidbody rigidBody;
        public Rigidbody Rigidbody => rigidBody;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AnimationController animationController;
        public AnimationController AnimationController => animationController;
        [SerializeField] private BasePlayerSo basePlayerSo;

        private BasePlayerRuntime characterRuntime;
        public BasePlayerRuntime CharacterRuntime => characterRuntime;
        private List<BasePlayerSkillRuntime> skillsRuntime = new List<BasePlayerSkillRuntime>();
        public List<BasePlayerSkillRuntime> SkillsRuntime => skillsRuntime;

        private MoveStateMachine<PlayerState> moveStateMachine;
        private AttackStateMachine<PlayerState> attackStateMachine;

        private readonly ILookAtMouseService lookAtMouseService = new LookAtMouseService();

        protected override void Awake()
        {
            base.Awake();
            InitStateMachine();
        }

        private void Update()
        {
            UpdateSkillCooldowns();

            moveStateMachine.UpdateState();
            attackStateMachine.UpdateState();

            LookAtMouse();
            HandleAttackInput();
        }

        private void FixedUpdate()
        {
            moveStateMachine.FixedUpdateState();
        }

        private void UpdateSkillCooldowns()
        {
            float dt = Time.deltaTime;
            foreach (var skill in skillsRuntime)
            {
                skill.UpdateCooldown(dt);
            }
        }

        private void HandleAttackInput()
        {
            var attack = InputManager.Ins.Attack;
            var attack2 = InputManager.Ins.Attack2;

            if (attack)
            {
                attackStateMachine.ChangeState(PlayerState.Skill1);
            }
            else if (attack2)
            {
                attackStateMachine.ChangeState(PlayerState.Skill2);
            }
            else
            {
                attackStateMachine.ChangeState(PlayerState.NormalAttack);
            }
        }

        void LookAtMouse()
        {
            var mousePos = InputManager.Ins.Look;
            lookAtMouseService.LookAtMouse(mainCamera, mousePos, transform);
        }

        #region Init

        void InitStateMachine()
        {
            moveStateMachine = new MoveStateMachine<PlayerState>();
            moveStateMachine.AddState(PlayerState.Idle, new PlayerIdleState(this, moveStateMachine));
            moveStateMachine.AddState(PlayerState.Move, new PlayerMoveState(this, moveStateMachine));
            moveStateMachine.SetInitState(PlayerState.Idle);

            attackStateMachine = new AttackStateMachine<PlayerState>();
            attackStateMachine.AddState(PlayerState.NormalAttack,
                new PlayerNormalAttackState(this, attackStateMachine));
            attackStateMachine.AddState(PlayerState.Skill1, new PlayerSkill1State(this, attackStateMachine));
            attackStateMachine.AddState(PlayerState.Skill2, new PlayerSkill2State(this, attackStateMachine));
            attackStateMachine.SetInitState(PlayerState.NormalAttack);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (animator == null)
            {
                Debug.LogWarning($"{animator} is null");
                animator = GetComponentInChildren<Animator>();
            }

            if (rigidBody == null)
            {
                Debug.LogWarning($"{rigidBody} is null");
                rigidBody = GetComponent<Rigidbody>();
            }

            if (mainCamera == null)
            {
                Debug.LogWarning($"{mainCamera} is null");
                mainCamera = Camera.main;
            }

            if (animationController == null)
            {
                Debug.LogWarning($"{animationController} is null");
                animationController = GetComponentInChildren<AnimationController>();
            }

            if (basePlayerSo == null)
            {
                Debug.LogWarning($"{basePlayerSo} is null");
                basePlayerSo = SoManager.Ins.GetPlayerSoByName(nameof(PlayerName.Yasuo));
            }

            InitializeRuntimes();
        }

        private void InitializeRuntimes()
        {
            characterRuntime = new BasePlayerRuntime(basePlayerSo);

            foreach (var skillSo in basePlayerSo.skills)
            {
                skillsRuntime.Add(new BasePlayerSkillRuntime(skillSo));
            }
        }

        #endregion
    }
}