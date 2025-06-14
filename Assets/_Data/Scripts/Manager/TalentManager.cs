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
        AudioManager.Instance.PlaySFXClip("Click");
        if (this.talentTable.csPoint < this.talentTable.talents[index].pointCost) return;
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

    public void ShowTalentPanel()
    {
        AudioManager.Instance.PlaySFXClip("Click");
        this.LoadComponents();
        if (GameManager.Instance.enabled)
        {
            this.talentTable.csPoint += GameManager.Instance.CSCount;
            this.csPointText.text = $"Điểm CS: {this.talentTable.csPoint}";
            GameManager.Instance.CSCount = 0;
        }
        this.talentPanel.SetActive(true);
    }

    public void CloseTalentPanel()
    {
        AudioManager.Instance.PlaySFXClip("Click");
        this.talentPanel.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTalentPanel();
        this.LoadCSPointText();
        this.LoadTalentsContent();
        this.LoadTalentTable();
        this.LoadUpgradeTable();
        this.LoadTalentsList();
        this.LoadTalentIcons();
        this.LoadTalentEffect();
        this.LoadCSPoint();
        this.LoadTalentLevel();
        this.LoadScoreBars();
    }

    void LoadCSPointText()
    {
        if (this.csPointText != null) return;
        this.csPointText = talentPanel.transform.Find("CSPoint").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCsPointText", this.gameObject);
    }

    void LoadTalentPanel()
    {
        if (this.talentPanel != null) return;
        this.talentPanel = GameObject.Find("TalentPanel");
        Debug.LogWarning(this.transform.name + ": LoadTalentPanel", this.gameObject);
    }

    void LoadTalentsContent()
    {
        if (this.talentsContent != null) return;
        this.talentsContent = GameObject.Find("Content").transform;
        Debug.LogWarning(this.transform.name + ": LoadTalentsContent", this.gameObject);
    }

    void LoadTalentTable()
    {
        if (this.talentTable != null) return;
        this.talentTable = Resources.Load<TalentTable>("Stat/TalentTable");
        Debug.LogWarning(this.transform.name + ": LoadTalentTable", this.gameObject);
    }

    void LoadUpgradeTable()
    {
        if (this.upgradeTable != null) return;
        this.upgradeTable = Resources.Load<UpgradeTable>("Stat/UpgradeTable");
        Debug.LogWarning(this.transform.name + ": LoadUpgradeTable", this.gameObject);
    }

    void LoadTalentsList()
    {
        this.talentsList.Clear();
        foreach (Transform item in this.talentsContent)
        {
            this.talentsList.Add(item);
        }
    }

    void LoadTalentIcons()
    {
        this.talentIcons.Clear();
        foreach (var item in this.talentsList)
        {
            Image itemIcon = item.transform.Find("Icon").Find("Image").GetComponent<Image>();
            this.talentIcons.Add(itemIcon);
        }

        for (int i = 0; i < this.talentsList.Count; i++)
        {
            this.talentIcons[i].sprite = this.talentTable.talents[i].icon;
        }
    }

    void LoadTalentEffect()
    {
        this.talentEffect.Clear();
        foreach (var item in this.talentsList)
        {
            TMP_Text itemEffectName = item.transform.Find("Info").Find("Effect").GetComponent<TMP_Text>();
            this.talentEffect.Add(itemEffectName);
        }

        for (int i = 0; i < this.talentEffect.Count; i++)
        {
            this.talentEffect[i].text =
                $"{this.talentTable.talents[i].effectName} +{this.talentTable.talents[i].effectValue}";
        }
    }

    void LoadCSPoint()
    {
        this.csPoint.Clear();
        foreach (var item in this.talentsList)
        {
            TMP_Text itemCSPoint = item.transform.Find("Info").Find("CSPoint").GetComponent<TMP_Text>();
            this.csPoint.Add(itemCSPoint);
        }

        for (int i = 0; i < this.csPoint.Count; i++)
        {
            this.csPoint[i].text = $"Điểm CS cần: {this.talentTable.talents[i].pointCost}";
        }
    }

    void LoadTalentLevel()
    {
        this.talentLevel.Clear();
        foreach (var item in this.talentsList)
        {
            TMP_Text itemTalentLevel = item.transform.Find("Info").Find("Level").GetComponent<TMP_Text>();
            this.talentLevel.Add(itemTalentLevel);
        }

        for (int i = 0; i < this.talentLevel.Count; i++)
        {
            this.talentLevel[i].text = $"Cấp độ: {this.talentTable.talents[i].currentLevel}";
        }
    }

    void LoadScoreBars()
    {
        this.scoreBars.Clear();
        foreach (var item in this.talentsList)
        {
            Image itemScoreBar = item.transform.Find("ScoreBar").Find("Score").GetComponent<Image>();
            this.scoreBars.Add(itemScoreBar);
        }

        foreach (var item in this.scoreBars)
        {
            item.fillAmount = 0f;
        }
    }
}