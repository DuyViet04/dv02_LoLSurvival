using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TalentManager : VyesSingleton<TalentManager>
{
    [SerializeField] private GameObject talentPanel;
    [SerializeField] private TMP_Text csPointText;
    [SerializeField] private Transform talentsContent;
    [SerializeField] private TalentTable talentTable;
    [SerializeField] private UpgradeTable upgradeTable;
    [SerializeField] private List<Transform> talentsList;
    [SerializeField] private List<Image> talentIcons;
    [SerializeField] private List<TMP_Text> talentEffect;
    [SerializeField] private List<TMP_Text> csPoint;
    [SerializeField] private List<TMP_Text> talentLevel;
    [SerializeField] private List<Image> scoreBars;

    protected override void Awake()
    {
        base.Awake();
        this.talentPanel.SetActive(false);
    }

    public void LevelUpTalent(int index)
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        if (this.talentTable.csPoint > this.talentTable.talents[index].pointCost)
        {
            this.talentTable.talents[index].currentLevel++;
            this.talentTable.csPoint -= this.talentTable.talents[index].pointCost;
            this.csPointText.text = $"Điểm CS: {this.talentTable.csPoint}";
            UpgradeData upgrade = this.upgradeTable.upgrades[index];
            this.talentTable.talents[index].effectValue += upgrade.value;
            this.talentTable.talents[index].pointCost += 50;

            this.talentLevel[index].text = $"Cấp độ: {this.talentTable.talents[index].currentLevel}";
            this.talentEffect[index].text =
                $"{this.talentTable.talents[index].effectName} +{this.talentTable.talents[index].effectValue}";
            this.csPoint[index].text = $"Điểm CS cần: {this.talentTable.talents[index].pointCost}";
        }
    }

    public void ShowTalentPanel()
    {
        SaveManager.Instance.LoadGame();
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        this.talentTable.csPoint += GameManager.Instance.CSCount;
        this.csPointText.text = $"Điểm CS: {this.talentTable.csPoint}";
        GameManager.Instance.CSCount = 0;
        for (int i = 0; i < this.talentsList.Count; i++)
        {
            this.talentLevel[i].text = $"Cấp độ: {this.talentTable.talents[i].currentLevel}";
            this.talentEffect[i].text =
                $"{this.talentTable.talents[i].effectName} +{this.talentTable.talents[i].effectValue}";
            this.csPoint[i].text = $"Điểm CS cần: {this.talentTable.talents[i].pointCost}";
        }

        this.talentPanel.SetActive(true);
    }

    public void CloseTalentPanel()
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        this.talentPanel.SetActive(false);
        SaveManager.Instance.SaveGame();
    }
}