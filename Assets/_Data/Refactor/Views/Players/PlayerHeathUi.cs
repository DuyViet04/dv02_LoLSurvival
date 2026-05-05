using _Data.Refactor.Controllers.Players;
using Base.Core.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Players
{
    public enum HealthUiObj
    {
        Hp,
        HpText,
        HpRegenText
    }

    public class PlayerHeathUi : BaseView
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private Image hp;
        [SerializeField] private TMP_Text hpText;
        [SerializeField] private TMP_Text hpRegenText;

        private void OnEnable()
        {
            playerHealth.OnHealthChanged += UpdateHealthUI;
            playerHealth.OnHealthRegenChanged += UpdateHealthRegenUI;
        }

        private void OnDisable()
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI;
            playerHealth.OnHealthRegenChanged -= UpdateHealthRegenUI;
        }

        private void UpdateHealthRegenUI(float hpRegen)
        {
            hpRegenText.text = $"+{hpRegen:0.0}/s";
        }

        private void UpdateHealthUI(float currentHp, float maxHp)
        {
            hp.fillAmount = currentHp / maxHp;
            hpText.text = $"{currentHp:N0} / {maxHp:N0}";
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerHealth == null)
            {
                playerHealth = FindFirstObjectByType<PlayerHealth>();
                Debug.LogWarning($"Load {playerHealth}", gameObject);
            }

            if (hp == null)
            {
                hp = transform.Find(nameof(HealthUiObj.Hp)).GetComponent<Image>();
                Debug.LogWarning($"Load {hp}", gameObject);
            }

            if (hpText == null)
            {
                hpText = transform.Find(nameof(HealthUiObj.HpText)).GetComponent<TMP_Text>();
                Debug.LogWarning($"Load {hpText}", gameObject);
            }

            if (hpRegenText == null)
            {
                hpRegenText = transform.Find(nameof(HealthUiObj.HpRegenText)).GetComponent<TMP_Text>();
                Debug.LogWarning($"Load {hpRegenText}", gameObject);
            }
        }
    }
}