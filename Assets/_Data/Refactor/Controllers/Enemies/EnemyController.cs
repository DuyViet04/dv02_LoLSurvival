using _Data.Refactor.States.Enemies;
using _Data.Refactor.States.Enemies.Moves;
using UnityEngine;
using VyesBase.Core.Architecture;

namespace _Data.Refactor.Controllers.Enemies
{
    // TODO: Spawner, EnemyData
    public class EnemyController : BaseController
    {
        [SerializeField] private Rigidbody rigid;
        public Rigidbody Rigidbody => rigid;
        [SerializeField] private Transform target;
        public Transform Target => target;

        private EnemyMoveStateMachine<EnemyState> moveStateMachine;

        protected override void Awake()
        {
            base.Awake();
            InitState();
        }

        void InitState()
        {
            moveStateMachine.AddState(EnemyState.Chase, new EnemyChaseState(this, moveStateMachine));
            moveStateMachine.SetInitState(EnemyState.Chase);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (rigid == null) rigid = GetComponent<Rigidbody>();
            if (target == null) target = GameObject.FindGameObjectWithTag(nameof(Enums.TagEnum.Player)).transform;
        }
    }
}