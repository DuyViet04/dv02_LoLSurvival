using _Data.Refactor.Models.SOs.Talents;
using _Data.Refactor.Services.Talents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.UIs
{
    public class TalentItemView : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private Image scoreBarImage;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text effectText;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private Button upgradeButton;

        private TalentSo talentSo;

        public void SetTalent(TalentSo talent)
        {
            this.talentSo = talent;
            UpdateUI();

            upgradeButton.onClick.RemoveAllListeners();
            upgradeButton.onClick.AddListener(OnUpgradeClick);
        }

        public void UpdateUI()
        {
            int currentLevel = TalentService.Ins.GetTalentLevel(talentSo.talentId);

            iconImage.sprite = talentSo.icon;
            levelText.text = $"Cấp độ: {currentLevel}";

            float currentEffect = talentSo.GetEffectValue(currentLevel);
            effectText.text = $"{talentSo.talentName}: +{currentEffect}";

            if (scoreBarImage != null)
            {
                float totalSpent = talentSo.GetTotalCostToLevel(currentLevel);
                float totalRequired = talentSo.GetTotalCostToLevel(talentSo.maxLevel);
                scoreBarImage.fillAmount = totalSpent / totalRequired;
            }

            if (currentLevel >= talentSo.maxLevel)
            {
                costText.text = "Cấp độ tối đa";
                upgradeButton.interactable = false;
            }
            else
            {
                int cost = talentSo.GetCost(currentLevel);
                costText.text = $"Điểm CS cần: {cost}";
                upgradeButton.interactable = TalentService.Ins.CanUpgrade(talentSo);
            }
        }

        private void OnUpgradeClick()
        {
            TalentService.Ins.UpgradeTalent(talentSo);
        }
    }
}