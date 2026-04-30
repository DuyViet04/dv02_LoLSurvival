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
            playerController.CharacterRuntime.DefensiveData.HealPower.OnValueChange += UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.LifeSteal.OnValueChange += UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.PhysicalVamp.OnValueChange += UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.Omnivamp.OnValueChange += UpdateHealData;
            playerController.CharacterRuntime.DefensiveData.Armor.OnValueChange += UpdateArmor;
            playerController.CharacterRuntime.DefensiveData.MagicResist.OnValueChange += UpdateMagicResist;
        }

        private void OnDisable()
        {
            playerController.CharacterRuntime.DefensiveData.Health.OnValueChange -= UpdateMaxHealth;
            playerController.CharacterRuntime.DefensiveData.HealthRegen.OnValueChange -= UpdateHealthRegen;
            playerController.CharacterRuntime.DefensiveData.HealPower.OnValueChange -= UpdateHealthRegen;
            playerController.CharacterRuntime.DefensiveData.HealPower.OnValueChange -= UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.LifeSteal.OnValueChange -= UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.PhysicalVamp.OnValueChange -= UpdateHealData;
            playerController.CharacterRuntime.OffensiveData.Omnivamp.OnValueChange -= UpdateHealData;
            playerController.CharacterRuntime.DefensiveData.Armor.OnValueChange -= UpdateArmor;
            playerController.CharacterRuntime.DefensiveData.MagicResist.OnValueChange -= UpdateMagicResist;
        }

        protected override void Awake()
        {
            health = playerController.CharacterRuntime.DefensiveData.Health.Value;
            healthRegen = playerController.CharacterRuntime.CurrentHealthRegen;
            UpdateArmor();
            UpdateMagicResist();
            UpdateHealData();
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

        void UpdateHealData()
        {
            healData.SetHealData(playerController.CharacterRuntime.OffensiveData.LifeSteal.Value,
                playerController.CharacterRuntime.OffensiveData.PhysicalVamp.Value,
                playerController.CharacterRuntime.OffensiveData.Omnivamp.Value,
                playerController.CharacterRuntime.DefensiveData.HealPower.Value);
        }

        void UpdateArmor()
        {
            armor = playerController.CharacterRuntime.DefensiveData.Armor.Value;
        }

        void UpdateMagicResist()
        {
            magicResist = playerController.CharacterRuntime.DefensiveData.MagicResist.Value;
        }
    }
}