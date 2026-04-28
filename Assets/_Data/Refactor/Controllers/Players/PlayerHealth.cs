using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    public class PlayerHealth : BaseHealth
    {
        [SerializeField] private PlayerController playerController;

        private void OnEnable()
        {
            playerController.CharacterRuntime.DefensiveData.Health.OnValueChange += UpdateMaxHealth;
            playerController.CharacterRuntime.DefensiveData.HealthRegen.OnValueChange += UpdateHealthRegen;
            playerController.CharacterRuntime.DefensiveData.HealPower.OnValueChange += UpdateHealthRegen;
        }

        private void OnDisable()
        {
            playerController.CharacterRuntime.DefensiveData.Health.OnValueChange -= UpdateMaxHealth;
            playerController.CharacterRuntime.DefensiveData.HealthRegen.OnValueChange -= UpdateHealthRegen;
            playerController.CharacterRuntime.DefensiveData.HealPower.OnValueChange -= UpdateHealthRegen;
        }

        protected override void Awake()
        {
            health = playerController.CharacterRuntime.DefensiveData.Health.Value;
            healthRegen = playerController.CharacterRuntime.CurrentHealthRegen;
            base.Awake();
        }

        void UpdateMaxHealth()
        {
            health = playerController.CharacterRuntime.DefensiveData.Health.Value;
            OnHealthChange();
        }

        void UpdateHealthRegen()
        {
            healthRegen = playerController.CharacterRuntime.CurrentHealthRegen;
            OnHealthRegenChange();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                Debug.LogWarning($"Load {playerController}", gameObject);
                playerController = GetComponent<PlayerController>();
            }
        }
    }
}