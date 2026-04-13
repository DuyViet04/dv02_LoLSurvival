using _Data.Refactor.Enums.Players;
using _Data.Refactor.Enums.Skills;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Models.SOs.Skills;
using _Data.Refactor.Services.LookAtMouse;
using _Data.Refactor.States.Players;
using _Data.Refactor.States.Players.Attacks;
using _Data.Refactor.States.Players.Moves;
using UnityEngine;
using VyesBase.Core.Architecture;
using VyesBase.Systems.Animation;
using VyesBase.Systems.Input;

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
        [SerializeField] private AnimEventController eventController;
        public AnimEventController EventController => eventController;
        [SerializeField] private BasePlayerSo basePlayerSo;

        private MoveStateMachine<PlayerState> moveStateMachine;
        private AttackStateMachine<PlayerState> attackStateMachine;

        private BasePlayerSoRuntime characterRuntime;
        public BasePlayerSoRuntime Runtime => characterRuntime;

        private BasePlayerSkillSoRuntime normalAttackRuntime;
        public BasePlayerSkillSoRuntime NormalAttackRuntime => normalAttackRuntime;
        private BasePlayerSkillSoRuntime skill1Runtime;
        public BasePlayerSkillSoRuntime Skill1Runtime => skill1Runtime;
        private BasePlayerSkillSoRuntime skill2Runtime;
        public BasePlayerSkillSoRuntime Skill2Runtime => skill2Runtime;

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

        private void UpdateSkillCooldowns()
        {
            float dt = Time.deltaTime;
            normalAttackRuntime?.UpdateCooldown(dt);
            skill1Runtime?.UpdateCooldown(dt);
            skill2Runtime?.UpdateCooldown(dt);
        }

        private void HandleAttackInput()
        {
            var attack = InputManager.Instance.Attack;
            var attack2 = InputManager.Instance.Attack2;

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
            var mousePos = InputManager.Instance.MousePosition;
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
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();
            if (mainCamera == null) mainCamera = Camera.main;
            if (eventController == null) eventController = GetComponentInChildren<AnimEventController>();
            if (basePlayerSo == null) basePlayerSo = SoManager.Instance.GetPlayerSoByName(nameof(PlayerName.Yasuo));

            InitializeRuntimes();
        }

        private void InitializeRuntimes()
        {
            characterRuntime = (BasePlayerSoRuntime)basePlayerSo.CreateRuntime();

            foreach (var skillSo in basePlayerSo.skills)
            {
                if (skillSo is BasePlayerSkillSo playerSkillSo)
                {
                    var runtime = (BasePlayerSkillSoRuntime)playerSkillSo.CreateRuntime();
                    switch (playerSkillSo.skillType)
                    {
                        case SkillType.NormalAttack:
                            normalAttackRuntime = runtime;
                            break;
                        case SkillType.Skill1:
                            skill1Runtime = runtime;
                            break;
                        case SkillType.Skill2:
                            skill2Runtime = runtime;
                            break;
                    }
                }
            }
        }

        #endregion
    }
}