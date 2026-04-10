using _Data.Refactor.Enums.Players;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Services.LookAtMouse;
using _Data.Refactor.States.Players;
using _Data.Refactor.States.Players.Attacks;
using _Data.Refactor.States.Players.Moves;
using UnityEngine;
using VyesBase.Core.Architecture;
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
        public Camera MainCamera => mainCamera;
        [SerializeField] private BasePlayerSo basePlayerSo;
        public BasePlayerSo BasePlayerSo => basePlayerSo;

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
            moveStateMachine.UpdateSate();
            attackStateMachine.UpdateSate();

            LookAtMouse();

            var attack = InputManager.Instance.Attack;
            var attack2 = InputManager.Instance.Attack2;
            if (attack)
            {
                attackStateMachine.ChangeState(PlayerState.Skill1);
            }

            if (attack2)
            {
                attackStateMachine.ChangeState(PlayerState.Skill2);
            }
        }

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

        void LookAtMouse()
        {
            var mousePos = InputManager.Instance.MousePosition;
            lookAtMouseService.LookAtMouse(mainCamera, mousePos, transform);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();
            if (mainCamera == null) mainCamera = Camera.main;
            if (basePlayerSo == null) basePlayerSo = SoManager.Instance.GetPlayerSoByName(nameof(PlayerName.Yasuo));
        }
    }
}