using System;
using System.Collections.Generic;
using _Data.Refactor.Controllers.Spawners;
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
using Base.Systems.Combat;
using Base.Systems.Input;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    [DefaultExecutionOrder(-100)]
    public class PlayerController : BaseController
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AnimationController animationController;
        [SerializeField] private BasePlayerSo basePlayerSo;
        [SerializeField] private Collider weaponCollider;
        [SerializeField] private SphereCollider sphereCollider;
        [SerializeField] private VfxSpawner vfxSpawner;
        private BasePlayerRuntime characterRuntime;
        private List<BasePlayerSkillRuntime> skillsRuntime = new List<BasePlayerSkillRuntime>();
        private AttackData skillAttackData = new AttackData();

        public Animator Animator => animator;
        public Rigidbody Rigidbody => rigidBody;
        public AnimationController AnimationController => animationController;
        public Collider WeaponCollider => weaponCollider;
        public BasePlayerRuntime CharacterRuntime => characterRuntime;
        public List<BasePlayerSkillRuntime> SkillsRuntime => skillsRuntime;
        public VfxSpawner VfxSpawner => vfxSpawner;
        public AttackData SkillAttackData => skillAttackData;

        private MoveStateMachine<PlayerState> moveStateMachine;
        private AttackStateMachine<PlayerState> attackStateMachine;

        private readonly ILookAtMouseService lookAtMouseService = new LookAtMouseService();

        private void OnEnable()
        {
            characterRuntime.PlayerData.PickUpRange.OnValueChange += UpdatePickUpRange;
        }

        private void OnDisable()
        {
            characterRuntime.PlayerData.PickUpRange.OnValueChange -= UpdatePickUpRange;
        }

        protected override void Awake()
        {
            base.Awake();
            InitializeRuntimes();
            InitStateMachine();
        }

        private void Start()
        {
            sphereCollider.radius = characterRuntime.PlayerData.PickUpRange.Value;

            // Passive
            characterRuntime.OffensiveData.CritChance.AddModifier(new StatModifier(2, ModifierType.PercentMult));
            characterRuntime.OffensiveData.CritDamage.AddModifier(new StatModifier(0.9f, ModifierType.PercentMult));
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
            attackStateMachine.FixedUpdateState();
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
            var mousePos = InputManager.Ins.Mouse;
            lookAtMouseService.LookAtMouse(mainCamera, mousePos, transform);
        }

        void UpdatePickUpRange()
        {
            sphereCollider.radius = characterRuntime.PlayerData.PickUpRange.Value;
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
                animator = GetComponentInChildren<Animator>();
                Debug.LogWarning($"{animator} is null", gameObject);
            }

            if (rigidBody == null)
            {
                rigidBody = GetComponent<Rigidbody>();
                Debug.LogWarning($"{rigidBody} is null", gameObject);
            }

            if (mainCamera == null)
            {
                mainCamera = Camera.main;
                Debug.LogWarning($"{mainCamera} is null", gameObject);
            }

            if (animationController == null)
            {
                animationController = GetComponentInChildren<AnimationController>();
                Debug.LogWarning($"{animationController} is null", gameObject);
            }

            if (basePlayerSo == null)
            {
                basePlayerSo = SoManager.Ins.GetPlayerSoByName(nameof(PlayerName.Yasuo));
                Debug.LogWarning($"{basePlayerSo} is null", gameObject);
            }

            if (vfxSpawner == null)
            {
                vfxSpawner = FindFirstObjectByType<VfxSpawner>();
                Debug.LogWarning($"{vfxSpawner} is null", gameObject);
            }
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