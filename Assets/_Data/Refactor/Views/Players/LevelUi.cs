using _Data.Refactor.Controllers.Players;
using Base.Core.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Players
{
    public enum LevelUiType
    {
        ExpBar,
        LevelText
    }

    public class LevelUi : BaseView
    {
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private Image expBar;
        [SerializeField] private TMP_Text levelText;

        private void OnEnable()
        {
            playerLevel.OnLevelUp += UpdateLevelText;
            playerLevel.OnExpChange += UpdateExpBar;
        }

        private void OnDisable()
        {
            playerLevel.OnLevelUp -= UpdateLevelText;
            playerLevel.OnExpChange -= UpdateExpBar;
        }

        private void UpdateExpBar(float currentExp, float maxExp)
        {
            expBar.fillAmount = currentExp / maxExp;
        }

        private void UpdateLevelText(int level)
        {
            levelText.text = $"{level}";
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerLevel == null)
            {
                playerLevel = FindFirstObjectByType<PlayerLevel>();
                Debug.LogWarning($"Load {playerLevel}", gameObject);
            }

            if (expBar == null)
            {
                expBar = transform.Find(nameof(LevelUiType.ExpBar)).GetComponent<Image>();
                Debug.LogWarning($"Load {expBar}", gameObject);
            }

            if (levelText == null)
            {
                levelText = transform.Find(nameof(LevelUiType.LevelText)).GetComponent<TMP_Text>();
                Debug.LogWarning($"Load {levelText}", gameObject);
            }
        }
    }
}