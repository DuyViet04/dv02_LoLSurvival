using System.Collections.Generic;
using _Data.Refactor.Controllers.Players;
using Base.Core.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Panels
{
    public class StatsPanel : BaseView
    {
        [SerializeField] private PlayerController playerController;

        [SerializeField] private Image mainBtnImg;
        [SerializeField] private Image secondBtnImg;
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject secondPanel;
        [SerializeField] private List<TMP_Text> mainStats;
        [SerializeField] private List<TMP_Text> secondStats;

        private void OnEnable()
        {
            if (mainPanel.activeSelf) OnUpdateMainData();
            if (secondPanel.activeSelf) OnUpdateSecondData();
        }

        public void ShowMainPanel()
        {
            mainPanel.SetActive(true);
            Color mainColor = mainBtnImg.color;
            mainColor.a = Mathf.Clamp01(0f / 255f);
            mainBtnImg.color = mainColor;

            secondPanel.SetActive(false);
            Color secondColor = secondBtnImg.color;
            secondColor.a = Mathf.Clamp01(200f / 255f);
            secondBtnImg.color = secondColor;

            OnUpdateMainData();
        }

        public void ShowSecondPanel()
        {
            mainPanel.SetActive(false);
            Color mainColor = mainBtnImg.color;
            mainColor.a = Mathf.Clamp01(200f / 255f);
            mainBtnImg.color = mainColor;

            secondPanel.SetActive(true);
            Color secondColor = secondBtnImg.color;
            secondColor.a = Mathf.Clamp01(0f / 255f);
            secondBtnImg.color = secondColor;

            OnUpdateSecondData();
        }

        void OnUpdateMainData()
        {
            mainStats[0].text = $"{playerController.CharacterRuntime.LevelData.CurrentLevel:N0}";
            mainStats[1].text = $"{playerController.CharacterRuntime.DefensiveData.Health.Value:N0}";
            mainStats[2].text = $"{playerController.CharacterRuntime.DefensiveData.HealthRegen.Value:0.00}";
            mainStats[3].text = $"{playerController.CharacterRuntime.OffensiveData.AttackDamage.Value:N0}";
            mainStats[4].text = $"{playerController.CharacterRuntime.OffensiveData.AbilityPower.Value:N0}";
            mainStats[5].text = $"{playerController.CharacterRuntime.DefensiveData.Armor.Value:N0}";
            mainStats[6].text = $"{playerController.CharacterRuntime.DefensiveData.MagicResist.Value:N0}";
            mainStats[7].text = $"{playerController.CharacterRuntime.UtilityData.MoveSpeed.Value:0.00}";
            mainStats[8].text = $"{playerController.CharacterRuntime.OffensiveData.CritChance.Value:N0}";
            mainStats[9].text = $"{playerController.CharacterRuntime.OffensiveData.CritDamage.Value:N0}";
            mainStats[10].text = $"{playerController.CharacterRuntime.OffensiveData.ArmorPenetration.Value:N0}";
            mainStats[11].text = $"{playerController.CharacterRuntime.OffensiveData.MagicPenetration.Value:N0}";
            mainStats[12].text = $"{playerController.CharacterRuntime.OffensiveData.LifeSteal.Value:N0}";
            mainStats[13].text = $"{playerController.CharacterRuntime.OffensiveData.Omnivamp.Value:N0}";
            mainStats[14].text = $"{playerController.CharacterRuntime.UtilityData.Haste.Value:N0}";
            mainStats[15].text = $"{playerController.CharacterRuntime.DefensiveData.HealPower.Value:N0}";
        }

        void OnUpdateSecondData()
        {
            secondStats[0].text = $"{playerController.CharacterRuntime.PlayerData.PickUpRange.Value:0.00}";
            secondStats[1].text = $"{playerController.CharacterRuntime.PlayerData.ExpMultiplier.Value:N0}";
        }
    }
}