using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using Base.Systems.Input;
using Base.Systems.Stat;
using Base.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VyesBase.Assets.Base.Systems.Game;

namespace _Data.Refactor.Views.UIs
{
    public enum LevelUpPanelObj
    {
        LevelUpPanel,
        Icon,
        Name,
        Value
    }

    public class LevelUpUi : VyesBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private GameObject levelUpPanel;
        [SerializeField] private List<GameObject> cores;
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
            InputManager.Ins.ChangeUiInput();
        }

        void HidePanel()
        {
            levelUpPanel.SetActive(false);
            GameManager.Ins.ResumeGame();
            InputManager.Ins.ChangePlayerInput();
        }

        void ShowUpgrades()
        {
            upgradeChoices = playerLevel.GetUpgrades(3);
            chosenRarity = playerLevel.RarityRuntime.GetRandomRarity();
            icons[0].sprite = upgradeChoices[0].icon;
            icons[1].sprite = upgradeChoices[1].icon;
            icons[2].sprite = upgradeChoices[2].icon;

            names[0].text = upgradeChoices[0].name;
            names[0].color = chosenRarity.color;
            names[1].text = upgradeChoices[1].name;
            names[1].color = chosenRarity.color;
            names[2].text = upgradeChoices[2].name;
            names[2].color = chosenRarity.color;

            values[0].text = (upgradeChoices[0].value * chosenRarity.power).ToString();
            values[0].color = chosenRarity.color;
            values[1].text = (upgradeChoices[1].value * chosenRarity.power).ToString();
            values[1].color = chosenRarity.color;
            values[2].text = (upgradeChoices[2].value * chosenRarity.power).ToString();
            values[2].color = chosenRarity.color;
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

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                playerController = FindFirstObjectByType<PlayerController>();
                Debug.LogWarning($"Load {playerController}", gameObject);
            }

            if (playerLevel == null)
            {
                playerLevel = FindFirstObjectByType<PlayerLevel>();
                Debug.LogWarning($"Load {playerLevel}", gameObject);
            }

            if (levelUpPanel == null)
            {
                levelUpPanel = transform.Find(nameof(LevelUpPanelObj.LevelUpPanel)).gameObject;
            }

            foreach (Transform child in levelUpPanel.transform)
            {
                cores.Add(child.gameObject);
                Image icon = child.transform.Find(nameof(LevelUpPanelObj.Icon)).GetComponent<Image>();
                TMP_Text name = child.transform.Find(nameof(LevelUpPanelObj.Name)).GetComponent<TMP_Text>();
                TMP_Text value = child.transform.Find(nameof(LevelUpPanelObj.Value)).GetComponent<TMP_Text>();
                icons.Add(icon);
                names.Add(name);
                values.Add(value);
            }
        }
    }
}