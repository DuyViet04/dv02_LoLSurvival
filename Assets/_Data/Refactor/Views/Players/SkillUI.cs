using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Models.Runtimes.Skills;
using Base.Core.Architecture;
using Base.Systems.Skill;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Players
{
    public enum SkillUiObj
    {
        Cd,
        CdTime
    }

    public class SkillUI : BaseView
    {
        [SerializeField] private PlayerController playerController;
        [Header("Skill1")] [SerializeField] private Image cd1;
        [SerializeField] private TMP_Text cdText1;
        private BasePlayerSkillRuntime skill1Runtime;
        [Header("Skill2")] [SerializeField] private Image cd2;
        [SerializeField] private TMP_Text cdText2;
        private BasePlayerSkillRuntime skill2Runtime;
        [Header("Info")] [SerializeField] private GameObject infoPanel;
        [SerializeField] private TMP_Text skillInfoText;

        protected override void Awake()
        {
            base.Awake();
            skill1Runtime = playerController.SkillsRuntime.Find(t => t.SkillData.SkillType == SkillType.Skill1);
            skill2Runtime = playerController.SkillsRuntime.Find(t => t.SkillData.SkillType == SkillType.Skill2);
            cdText1.text = "";
            cdText2.text = "";
        }

        private void OnEnable()
        {
            skill1Runtime.OnCooldownUpdated += UpdateCooldownUI1;
            skill2Runtime.OnCooldownUpdated += UpdateCooldownUI2;
        }

        private void OnDisable()
        {
            skill1Runtime.OnCooldownUpdated -= UpdateCooldownUI1;
            skill2Runtime.OnCooldownUpdated -= UpdateCooldownUI2;
        }

        private void UpdateCooldownUI1(float currentCdTime, float cdTime)
        {
            cd1.fillAmount = currentCdTime / cdTime;
            cdText1.text = currentCdTime > 0.01f ? $"{currentCdTime:0.0}s" : "";
        }

        private void UpdateCooldownUI2(float currentCdTime, float cdTime)
        {
            cd2.fillAmount = currentCdTime / cdTime;
            cdText2.text = currentCdTime > 0.01f ? $"{currentCdTime:0.0}s" : "";
        }

        public void ShowSkillInfo(int index)
        {
            infoPanel.SetActive(true);
            var offensive = playerController.CharacterRuntime.OffensiveData;
            float ad = offensive.AttackDamage;
            float ap = offensive.AbilityPower;
            switch (index)
            {
                case 1:
                    var d1 = skill1Runtime.SkillData;
                    float total1 = d1.BaseDamage + (ad * d1.BonusAd / 100f);
                    skillInfoText.text =
                        $"Yasuo tung ra một cơn lốc gây <color=red>{total1} = {d1.BaseDamage} + {d1.BonusAd}% AD sát thương vật lý</color>";
                    break;
                case 2:
                    var d2 = skill2Runtime.SkillData;
                    float total2 = d2.BaseDamage + (ap * d2.BonusAp / 100f);
                    skillInfoText.text =
                        $"Yasuo lướt đi 1 đoạn và gây <color=blue>{total2} = {d2.BaseDamage} + {d2.BonusAp}% AP sát thương phép thuật</color>";
                    break;
                default:
                    skillInfoText.text =
                        "Yasuo nhận gấp đôi tỉ lệ chí mạng, mỗi 1% tỉ lệ chí mạng vượt quá 100% sẽ chuyển thành <color=red>0.5 sức mạnh vật lý</color>";
                    break;
            }
        }

        public void HideSkillInfo()
        {
            infoPanel.SetActive(false);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                playerController = FindFirstObjectByType<PlayerController>();
                Debug.LogWarning($"Load {playerController}", gameObject);
            }

            Transform skill1 = transform.Find(nameof(SkillType.Skill1));
            if (cd1 == null)
            {
                cd1 = skill1.Find(nameof(SkillUiObj.Cd)).GetComponent<Image>();
                Debug.LogWarning($"Load {cd1}", gameObject);
            }

            if (cdText1 == null)
            {
                cdText1 = skill1.Find(nameof(SkillUiObj.CdTime)).GetComponent<TMP_Text>();
                Debug.LogWarning($"Load {cdText1}", gameObject);
            }

            Transform skill2 = transform.Find(nameof(SkillType.Skill2));
            if (cd2 == null)
            {
                cd2 = skill2.Find(nameof(SkillUiObj.Cd)).GetComponent<Image>();
                Debug.LogWarning($"Load {cd2}", gameObject);
            }

            if (cdText2 == null)
            {
                cdText2 = skill2.Find(nameof(SkillUiObj.CdTime)).GetComponent<TMP_Text>();
                Debug.LogWarning($"Load {cdText2}", gameObject);
            }
        }
    }
}