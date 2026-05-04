using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums.Bosses;
using _Data.Refactor.Models.Runtimes.Enemies;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.States.Bosses;
using _Data.Refactor.States.Bosses.Attacks;
using _Data.Refactor.States.Bosses.Moves;
using Base.Core.Architecture;
using Base.Systems.Combat;
using Base.Systems.Stat;
using _Data.Refactor.Views.Enemies;
using UnityEngine;
using System;
using _Data.Refactor.Enums;

namespace _Data.Refactor.Controllers.Enemies
{
    public class BossController : BaseController, IDamageable
    {
        [Header("Components")] [SerializeField]
        private Rigidbody rigidBody;

        [SerializeField] private Animator animator;
        [SerializeField] private Transform target;
        [SerializeField] private BaseBossSo baseBossSo;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private BossHpView hpView;
        [Header("Settings")] [SerializeField] private float scaleValue = 0.2f;
        private BaseBossRuntime bossRuntime;
        private BossMoveStateMachine<BossState> moveStateMachine;
        private BossAttackStateMachine<BossState> attackStateMachine;
        private float currentHealth;
        private float maxHealth;

        public Rigidbody Rigidbody => rigidBody;
        public Animator Animator => animator;
        public Transform Target => target;
        public BaseBossRuntime BossRuntime => bossRuntime;
        public BossAttackStateMachine<BossState> AttackStateMachine => attackStateMachine;

        public event Action<float, float> OnHealthChanged;

        private readonly DefenseData defenseData = new DefenseData();
        private readonly ICombatService combatService = new CombatService();

        protected override void Awake()
        {
            base.Awake();
            InitializeRuntimes();
            InitializeStates();
        }

        private void OnEnable()
        {
            playerLevel.OnLevelUpEvent += UpdateBossStats;

            if (playerLevel.CurrentLevel > 1)
            {
                ScaleBossStats(playerLevel.CurrentLevel - 1);
            }

            maxHealth = bossRuntime.DefensiveData.Health.Value;
            currentHealth = maxHealth;
            hpView.ShowBossHp(this);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void OnDisable()
        {
            playerLevel.OnLevelUpEvent -= UpdateBossStats;
        }

        private void Update()
        {
            moveStateMachine.UpdateState();
            attackStateMachine.UpdateState();
        }

        private void FixedUpdate()
        {
            moveStateMachine.FixedUpdateState();
            attackStateMachine.FixedUpdateState();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Player)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable.TakeDamage(bossRuntime.AttackData);
            }
        }

        public float TakeDamage(AttackData attackData)
        {
            defenseData.SetDefenseData(bossRuntime.DefensiveData.Armor.Value,
                bossRuntime.DefensiveData.MagicResist.Value);
            float damage = combatService.DamageCalculate(attackData, defenseData);

            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }

            return damage;
        }

        private void InitializeRuntimes()
        {
            bossRuntime = new BaseBossRuntime(baseBossSo);
        }

        private void InitializeStates()
        {
            moveStateMachine = new BossMoveStateMachine<BossState>();
            moveStateMachine.AddState(BossState.Chase, new BossChaseState(this, moveStateMachine));
            moveStateMachine.SetInitState(BossState.Chase);

            attackStateMachine = new BossAttackStateMachine<BossState>();
            attackStateMachine.AddState(BossState.Idle, new BossIdleState(this, attackStateMachine));
            attackStateMachine.AddState(BossState.Skill, new BossSkillState(this, attackStateMachine));
            attackStateMachine.SetInitState(BossState.Idle);
        }

        private void UpdateBossStats()
        {
            ScaleBossStats(1);
            float newMaxHealth = bossRuntime.DefensiveData.Health.Value;
            currentHealth += (newMaxHealth - maxHealth);
            maxHealth = newMaxHealth;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void ScaleBossStats(int levelDiff)
        {
            float scale = scaleValue * levelDiff;
            bossRuntime.DefensiveData.Health.AddModifier(new StatModifier(scale, ModifierType.PercentAdd));
            bossRuntime.DefensiveData.Armor.AddModifier(new StatModifier(scale, ModifierType.PercentAdd));
            bossRuntime.DefensiveData.MagicResist.AddModifier(new StatModifier(scale, ModifierType.PercentAdd));
            bossRuntime.UtilityData.MoveSpeed.AddModifier(new StatModifier(scale / 5f, ModifierType.PercentAdd));

            float attackScale = Mathf.Pow(1 + scaleValue, levelDiff);
            bossRuntime.AttackData.SetAttackData(
                bossRuntime.AttackData.Damage * attackScale,
                bossRuntime.AttackData.CanCrit,
                bossRuntime.AttackData.CritDamage,
                bossRuntime.AttackData.DamageType,
                bossRuntime.AttackData.Source);
        }

        private void Die()
        {
            hpView.HideBossHp();
            animator.SetTrigger("Die");
            gameObject.SetActive(false);
        }
    }
}