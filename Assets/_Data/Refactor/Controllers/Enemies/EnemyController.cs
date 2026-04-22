using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.Runtimes.Enemies;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.States.Enemies;
using _Data.Refactor.States.Enemies.Moves;
using Base.Core.Architecture;
using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Enemies
{
    // TODO: Spawner, EnemyData
    public class EnemyController : BaseController
    {
        [SerializeField] private Rigidbody rigid;
        [SerializeField] private Transform target;
        [SerializeField] private BaseEnemySo baseEnemySo;
        [SerializeField] private BulletSpawner bulletSpawner;
        private BaseEnemyRuntime baseEnemyRuntime;

        public Rigidbody Rigidbody => rigid;
        public Transform Target => target;
        public BulletSpawner BulletSpawner => bulletSpawner;
        public BaseEnemyRuntime BaseEnemyRuntime => baseEnemyRuntime;

        private EnemyMoveStateMachine<EnemyState> moveStateMachine;

        protected override void Awake()
        {
            base.Awake();
            baseEnemyRuntime = new BaseEnemyRuntime(baseEnemySo);
            InitState();
        }

        private void Update()
        {
            moveStateMachine.UpdateState();
        }

        private void FixedUpdate()
        {
            moveStateMachine.FixedUpdateState();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Player)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable.TakeDamage(baseEnemyRuntime.AttackData);
            }
        }

        void InitState()
        {
            moveStateMachine = new EnemyMoveStateMachine<EnemyState>();
            moveStateMachine.AddState(EnemyState.Chase, new EnemyChaseState(this, moveStateMachine));
            moveStateMachine.SetInitState(EnemyState.Chase);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
                Debug.LogWarning($"Load {rigid}", gameObject);
            }

            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag(nameof(TagEnum.Player)).transform;
                Debug.LogWarning($"Load {target}", gameObject);
            }

            if (baseEnemySo == null)
            {
                baseEnemySo = SoManager.Ins.GetEnemySoByName(transform.name);
                Debug.LogWarning($"Load {baseEnemySo}", gameObject);
            }

            if (bulletSpawner == null)
            {
                bulletSpawner = FindFirstObjectByType<BulletSpawner>();
                Debug.LogWarning($"Load {bulletSpawner}", gameObject);
            }
        }
    }
}