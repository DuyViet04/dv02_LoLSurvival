using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillDisplay : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TMP_Text skillInfoText;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private YasuoStats yasuoStats;

    public void ShowSkillInfo(int index)
    {
        this.infoPanel.SetActive(true);
        AttackData skill1 = this.yasuoSkill.yasuoSkillData[1];
        AttackData skill2 = this.yasuoSkill.yasuoSkillData[2];
        switch (index)
        {
            case 1:
                this.skillInfoText.text =
                    $"Yasuo tung ra một cơn lốc gây <color=red>{skill1.GetDamage(this.yasuoStats.attackDamage, this.yasuoStats.abilityPower)}" +
                    $" = {skill1.baseDamage} + {skill1.bonusAD}% AD sát thương vật lý</color>";
                LayoutRebuilder.ForceRebuildLayoutImmediate(infoPanel.GetComponent<RectTransform>());
                break;
            case 2:
                this.skillInfoText.text =
                    $"Yasuo lướt đi 1 đoạn và gây <color=blue>{skill2.GetDamage(this.yasuoStats.attackDamage, this.yasuoStats.abilityPower)}" +
                    $" = {skill2.baseDamage} + <color=red>{skill2.bonusAP}%  AD</color> + {skill2.bonusAP}% AP sát thương phép thuật</color>";
                LayoutRebuilder.ForceRebuildLayoutImmediate(infoPanel.GetComponent<RectTransform>());
                break;
            default:
                this.skillInfoText.text =
                    "Yasuo nhận gấp đôi tỉ lệ chí mạng, mỗi 1% tỉ lệ chí mạng vượt quá 100% sẽ chuyển thành <color=red>0.5 sức mạnh vật lý</color>";
                LayoutRebuilder.ForceRebuildLayoutImmediate(infoPanel.GetComponent<RectTransform>());
                break;
        }
    }

    public void HideSkillInfo()
    {
        this.infoPanel.SetActive(false);
    }
}