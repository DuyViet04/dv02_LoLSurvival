using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using Base.Core.Architecture;
using Base.Systems.Input;
using Base.Systems.Stat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VyesBase.Assets.Base.Systems.Game;

namespace _Data.Refactor.Views.Panels
{
    public class LevelUpPanel : BaseView
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private GameObject levelUpPanel;
        [SerializeField] private List<Image> icons;
        [SerializeField] private List<TMP_Text> names;
        [SerializeField] private List<TMP_Text> values;

        private List<UpgradeData> upgradeChoices;
        private RarityData chosenRarity;

        private readonly IStatService levelService = new StatService();

        private void OnEnable()
        {
            playerLevel.OnLevelUpEvent += ShowPanel;
        }

        private void OnDisable()
        {
            playerLevel.OnLevelUpEvent -= ShowPanel;
        }

        void ShowPanel()
        {
            levelUpPanel.SetActive(true);
            GameManager.Ins.PauseGame();
            ShowUpgrades();
        }

        void HidePanel()
        {
            levelUpPanel.SetActive(false);
            GameManager.Ins.ResumeGame();
        }

        void ShowUpgrades()
        {
            upgradeChoices = playerLevel.GetUpgrades(3);
            chosenRarity = playerLevel.RarityRuntime.GetRandomRarity();

            for (int i = 0; i < 3; i++)
            {
                icons[i].sprite = upgradeChoices[i].icon;
                names[i].text = upgradeChoices[i].name;
                names[i].color = chosenRarity.color;
                values[i].text = (upgradeChoices[i].value * chosenRarity.power).ToString();
                values[i].color = chosenRarity.color;
            }
        }

        public void SelectUpgrade(int choice)
        {
            var upgrade = upgradeChoices[choice];
            var stat = levelService.FindStat(upgrade.type, playerController.CharacterRuntime);
            var mod = upgrade.statModifier;
            var newMod = new StatModifier(mod.Value * chosenRarity.power, mod.Type);
            stat.AddModifier(newMod);

            HidePanel();
        }
    }
}