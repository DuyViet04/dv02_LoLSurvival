using _Data.Refactor.Enums.Players;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.States.Players;
using UnityEngine;
using VyesBase.Core.Architecture;
using VyesBase.Core.StateMachine;

namespace _Data.Refactor.Controllers.Players
{
    // Todo: Move
    public class PlayerController : BaseController
    {
        [SerializeField] private Animator animator;
        public Animator Animator => animator;
        [SerializeField] private Rigidbody rigidBody;
        public Rigidbody Rigidbody => rigidBody;
        [SerializeField] private BasePlayerSo basePlayerSo;
        public BasePlayerSo BasePlayerSo => basePlayerSo;

        private StateMachine<PlayerState> stateMachine;

        protected override void Awake()
        {
            base.Awake();
            stateMachine = new StateMachine<PlayerState>();
            stateMachine.AddState(PlayerState.Idle, new PlayerIdleState(this, stateMachine));
            stateMachine.AddState(PlayerState.Move, new PlayerMoveState(this, stateMachine));
            stateMachine.SetInitState(PlayerState.Idle);
        }

        private void Update()
        {
            stateMachine.UpdateSate();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();
            if (basePlayerSo == null) basePlayerSo = SoManager.Instance.GetPlayerSoByName(nameof(PlayerName.Yasuo));
        }
    }
}