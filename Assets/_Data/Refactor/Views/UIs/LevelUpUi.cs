using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.Runtimes.Upgrades;
using _Data.Refactor.Models.SOs.Upgrades;
using _Data.Refactor.Models.SOs.Upgrades.Data;
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
        [SerializeField] private UpgradeSo upgradeSo;
        [SerializeField] private RaritySo raritySo;
        [SerializeField] private GameObject levelUpPanel;
        [SerializeField] private List<GameObject> cores;
        [SerializeField] private List<Image> icons;
        [SerializeField] private List<TMP_Text> names;
        [SerializeField] private List<TMP_Text> values;

        private List<UpgradeData> upgrades;
        private List<UpgradeData> upgradeChoices;
        private RarityRuntime rarityRuntime;
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

        protected override void Awake()
        {
            base.Awake();
            upgrades = new List<UpgradeData>(upgradeSo.upgrades);
            rarityRuntime = new RarityRuntime(raritySo);
        }

        void ShowPanel()
        {
            levelUpPanel.SetActive(true);
            GameManager.Ins.PauseGame();
            ShowUpgrades();
        }

        public void HidePanel()
        {
            levelUpPanel.SetActive(false);
            GameManager.Ins.ResumeGame();
        }

        void ShowUpgrades()
        {
            GetUpgrades(3);
            chosenRarity = rarityRuntime.GetRandomRarity();
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

        List<UpgradeData> GetUpgrades(int value)
        {
            ListUtility.Shuffle(upgrades);
            return upgradeChoices = upgrades.GetRange(0, value);
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

            if (upgradeSo == null)
            {
                upgradeSo = SoManager.Ins.UpgradeSo;
                Debug.LogWarning($"Load {upgradeSo}", gameObject);
            }

            if (raritySo == null)
            {
                raritySo = SoManager.Ins.RaritySo;
                Debug.LogWarning($"Load {raritySo}", gameObject);
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