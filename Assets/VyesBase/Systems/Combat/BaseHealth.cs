using System;
using UnityEngine;
using VyesBase.Systems.Level;
using VyesBase.Utils.AutoBind;

namespace VyesBase.Systems.Combat
{
    public abstract class BaseHealth : MonoBehaviour, IDamageable
    {
        [Header("Settings")] 
        [SerializeField] protected float maxHealth = 100f;
        [SerializeField] protected float currentHealth;

        [Header("Stats")] 
        [SerializeField] protected float armor = 0f;
        [SerializeField] protected float magicResistance = 0f;

        [Header("Level Integration")]
        [SerializeField] protected bool scaleWithLevel = true;
        [SerializeField] protected float healthPerLevel = 20f;
        [SerializeField] protected float armorPerLevel = 2f;
        
        [SerializeField, AutoBind(BindScope.Self)] 
        protected BaseLevel levelComponent;

        public event Action<float, float> OnHealthChanged;
        public event Action<DamageData> OnDamageTaken;
        public event Action OnDeath;

        public float CurrentHealth => currentHealth;
        public float MaxHealth => maxHealth;
        public bool IsDead => currentHealth <= 0;

        public float Armor => armor;
        public float MagicResistance => magicResistance;

        // Mặc định khởi tạo CombatService để sẵn sàng sử dụng
        private ICombatService _combatService = new CombatService();

        protected virtual void OnEnable()
        {
            if (levelComponent != null)
            {
                levelComponent.OnLevelUp += HandleLevelUp;
            }
        }

        protected virtual void OnDisable()
        {
            if (levelComponent != null)
            {
                levelComponent.OnLevelUp -= HandleLevelUp;
            }
        }

        protected virtual void Start()
        {
            currentHealth = maxHealth;
        }

        protected virtual void HandleLevelUp(int newLevel)
        {
            if (!scaleWithLevel) return;

            // Tăng chỉ số
            maxHealth += healthPerLevel;
            armor += armorPerLevel;
            
            // Hồi đầy máu khi lên cấp
            ResetHealth();
            
            Debug.Log($"[LevelUp] {gameObject.name} reached level {newLevel}. Max HP: {maxHealth}, Armor: {armor}");
        }

        public virtual void TakeDamage(DamageData damageData)
        {
            if (IsDead) return;

            // Sử dụng service để tính toán sát thương thực tế
            float finalDamageAmount = damageData.Amount;
            if (_combatService != null)
            {
                finalDamageAmount = _combatService.CalculateFinalDamage(damageData, this);
            }

            currentHealth -= finalDamageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            OnDamageTaken?.Invoke(damageData);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            OnDeath?.Invoke();
            Debug.Log($"{gameObject.name} has died.");
        }

        public virtual void Heal(float amount)
        {
            if (IsDead) return;

            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public virtual void ResetHealth()
        {
            currentHealth = maxHealth;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void SetCombatService(ICombatService service)
        {
            _combatService = service;
        }
    }
}