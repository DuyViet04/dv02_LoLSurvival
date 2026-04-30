using System.Collections.Generic;
using _Data.Refactor.Models.Runtimes.Upgrades;
using _Data.Refactor.Models.SOs.Upgrades;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using Base.Systems.Level;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    public class PlayerLevel : BaseLevel
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UpgradeSo upgradeSo;
        [SerializeField] private RaritySo raritySo;

        private List<UpgradeData> upgrades;
        private RarityRuntime rarityRuntime;
        private readonly int maxRarityInLevel = 50;

        public RarityRuntime RarityRuntime => rarityRuntime;

        protected override void Awake()
        {
            base.Awake();
            upgrades = new List<UpgradeData>(upgradeSo.upgrades);
            rarityRuntime = new RarityRuntime(raritySo);

            currentLevel = playerController.CharacterRuntime.LevelData.CurrentLevel;
            expMultiplier = playerController.CharacterRuntime.PlayerData.ExpMultiplier.Value;
        }

        private void OnEnable()
        {
            OnLevelUpEvent += UpdateRarity;
        }

        private void OnDisable()
        {
            OnLevelUpEvent -= UpdateRarity;
        }

        protected override void MaxExpCalculate(int currentLevel)
        {
            maxExp = 180 + currentLevel * 100f;
        }

        public List<UpgradeData> GetUpgrades(int value)
        {
            ListUtility.Shuffle(upgrades);
            return upgrades.GetRange(0, value);
        }

        void UpdateRarity()
        {
            float baseIncreaseValue = 1f / (maxRarityInLevel - 1);
            float legendValue = baseIncreaseValue * 1 / 15;
            float epicValue = baseIncreaseValue * 2 / 15;
            float rareValue = baseIncreaseValue * 3 / 15;
            float uncommonValue = baseIncreaseValue * 4 / 15;

            rarityRuntime.Rarities[4].chance += legendValue;
            rarityRuntime.Rarities[3].chance += epicValue;
            rarityRuntime.Rarities[2].chance += rareValue;
            rarityRuntime.Rarities[1].chance += uncommonValue;
            rarityRuntime.Rarities[0].chance -= uncommonValue + rareValue + epicValue + legendValue;
        }
    }
}