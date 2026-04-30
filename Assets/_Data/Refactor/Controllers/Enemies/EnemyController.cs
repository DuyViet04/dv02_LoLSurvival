using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums;
using _Data.Refactor.Models.Runtimes.Enemies;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.States.Enemies;
using _Data.Refactor.States.Enemies.Moves;
using Base.Core.Architecture;
using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Enemies
{
    public class EnemyController : BaseController, IDamageable
    {
        [SerializeField] private Rigidbody rigid;
        [SerializeField] private Transform target;
        [SerializeField] private BaseEnemySo baseEnemySo;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private ExpSpawner expSpawner;
        [SerializeField] private EnemySpawner enemySpawner;
        private BaseEnemyRuntime baseEnemyRuntime;
        private readonly DefenseData defenseData = new DefenseData();
        private float currentHealth;
        private float maxHealth;
        private EnemyMoveStateMachine<EnemyState> moveStateMachine;

        public Rigidbody Rigidbody => rigid;
        public Transform Target => target;
        public BulletSpawner BulletSpawner => bulletSpawner;
        public ExpSpawner ExpSpawner => expSpawner;
        public EnemySpawner EnemySpawner => enemySpawner;
        public BaseEnemyRuntime BaseEnemyRuntime => baseEnemyRuntime;
        public EnemyMoveStateMachine<EnemyState> MoveStateMachine => moveStateMachine;

        private readonly ICombatService combatService = new CombatService();

        protected override void Awake()
        {
            base.Awake();
            baseEnemyRuntime = new BaseEnemyRuntime(baseEnemySo);
            InitState();
        }

        void Start()
        {
            maxHealth = baseEnemyRuntime.DefensiveData.Health.Value;
            currentHealth = maxHealth;
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
                var damage = damageable.TakeDamage(baseEnemyRuntime.AttackData);
            }
        }

        public float TakeDamage(AttackData attackData)
        {
            defenseData.SetDefenseData(baseEnemyRuntime.DefensiveData.Armor.Value,
                baseEnemyRuntime.DefensiveData.MagicResist.Value);
            float damage = combatService.DamageCalculate(attackData, defenseData);

            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (currentHealth <= 0)
            {
                moveStateMachine.ChangeState(EnemyState.Die);
            }

            return damage;
        }

        void InitState()
        {
            moveStateMachine = new EnemyMoveStateMachine<EnemyState>();
            moveStateMachine.AddState(EnemyState.Chase, new EnemyChaseState(this, moveStateMachine));
            moveStateMachine.AddState(EnemyState.Die, new EnemyDieState(this, moveStateMachine));
            moveStateMachine.SetInitState(EnemyState.Chase);
        }
    }
}