using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums;
using _Data.Refactor.Models.Runtimes.Enemies;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.States.Enemies;
using _Data.Refactor.States.Enemies.Moves;
using _Data.Refactor.Views.UIs;
using Base.Core.Architecture;
using Base.Systems.Combat;
using Base.Systems.Economy;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Enemies
{
    public class EnemyController : BaseController, IDamageable
    {
        [Header("Components")] [SerializeField]
        private Rigidbody rigid;

        [SerializeField] private Transform target;
        [SerializeField] private BaseEnemySo baseEnemySo;
        [Header("Spawner")] [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private ExpSpawner expSpawner;
        [SerializeField] private EnemySpawner enemySpawner;
        [Header("Scale")] [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private float scaleValue = 0.1f;
        [SerializeField] private CsUi csUi;
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

        private void OnEnable()
        {
            playerLevel.OnLevelUpEvent += UpdateEnemyStats;
        }

        private void OnDisable()
        {
            playerLevel.OnLevelUpEvent -= UpdateEnemyStats;
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
                damageable.TakeDamage(baseEnemyRuntime.AttackData);
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
                GoldManager.Ins.AddGold(baseEnemyRuntime.EnemyData.GoldValue.Value);
                csUi.UpdateCsCount(baseEnemyRuntime.EnemyData.CsValue.Value);
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

        void UpdateEnemyStats()
        {
            baseEnemyRuntime.DefensiveData.Health.AddModifier(new StatModifier(scaleValue, ModifierType.PercentAdd));
            baseEnemyRuntime.DefensiveData.Armor.AddModifier(new StatModifier(scaleValue, ModifierType.PercentAdd));
            baseEnemyRuntime.DefensiveData.MagicResist.AddModifier(
                new StatModifier(scaleValue, ModifierType.PercentAdd));
            baseEnemyRuntime.EnemyData.ExpValue.AddModifier(new StatModifier(scaleValue, ModifierType.PercentAdd));
            baseEnemyRuntime.EnemyData.GoldValue.AddModifier(new StatModifier(scaleValue, ModifierType.PercentAdd));
            baseEnemyRuntime.UtilityData.MoveSpeed.AddModifier(new StatModifier(scaleValue / 10,
                ModifierType.PercentAdd));
            baseEnemyRuntime.AttackData.SetAttackData(
                baseEnemyRuntime.AttackData.Damage * (1 + scaleValue),
                baseEnemyRuntime.AttackData.CanCrit,
                baseEnemyRuntime.AttackData.CritDamage,
                baseEnemyRuntime.AttackData.DamageType,
                baseEnemyRuntime.AttackData.Source);
        }
    }
}