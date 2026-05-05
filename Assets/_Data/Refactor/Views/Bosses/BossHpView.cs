using _Data.Refactor.Controllers.Bosses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Bosses
{
    public class BossHpView : MonoBehaviour
    {
        [SerializeField] private GameObject hpBar;
        [SerializeField] private Image hpImg;

        private BossController currentBoss;

        private void Start()
        {
            hpBar.SetActive(false);
        }

        public void ShowBossHp(BossController boss)
        {
            currentBoss = boss;
            hpBar.SetActive(true);
            currentBoss.OnHealthChanged += UpdateHp;
        }

        public void HideBossHp()
        {
            if (currentBoss != null)
            {
                currentBoss.OnHealthChanged -= UpdateHp;
            }

            hpBar.SetActive(false);
        }

        private void UpdateHp(float currentHealth, float maxHealth)
        {
            hpImg.fillAmount = currentHealth / maxHealth;
        }

        private void OnDestroy()
        {
            if (currentBoss != null)
            {
                currentBoss.OnHealthChanged -= UpdateHp;
            }
        }
    }
}