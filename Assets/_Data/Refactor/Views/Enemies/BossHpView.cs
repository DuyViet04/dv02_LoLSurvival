using _Data.Refactor.Controllers.Enemies;
using Base.Core.Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Enemies
{
    public class BossHpView : BaseView
    {
        [SerializeField] private GameObject hpPanel;
        [SerializeField] private Image hpBar;
        [SerializeField] private BossController currentBoss;

        protected override void Awake()
        {
            base.Awake();
            hpPanel.SetActive(false);
        }

        protected void OnDisable()
        {
            currentBoss.OnHealthChanged -= UpdateHealthUI;
        }

        public void ShowBossHp(BossController boss)
        {
            currentBoss = boss;
            currentBoss.OnHealthChanged += UpdateHealthUI;
            hpPanel.SetActive(true);
            UpdateHealthUI(boss.BossRuntime.DefensiveData.Health.Value, boss.BossRuntime.DefensiveData.Health.Value);
        }

        public void HideBossHp()
        {
            currentBoss.OnHealthChanged -= UpdateHealthUI;

            currentBoss = null;
            hpPanel.SetActive(false);
        }

        private void UpdateHealthUI(float currentHp, float maxHp)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}