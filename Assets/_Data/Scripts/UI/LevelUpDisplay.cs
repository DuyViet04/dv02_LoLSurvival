using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpDisplay : VyesSingleton<LevelUpDisplay>
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;
    [SerializeField] private List<GameObject> listCores;
    private RarityType chosenRarity;
    private int power;
    private List<Image> iconList;
    private List<TMP_Text> namesList;
    private List<TMP_Text> valuesList;
    private List<UpgradeData> choicesList;

    protected override void Awake()
    {
        base.Awake();
        this.iconList = new List<Image>();
        this.namesList = new List<TMP_Text>();
        this.valuesList = new List<TMP_Text>();
        this.LoadCoreData();
        this.LoadComponents();
    }

    public void ShowUpgradeChoices()
    {
        this.chosenRarity = this.rarityTable.GetRandomRarity();
        Color color = this.rarityTable.GetColorByRarity(chosenRarity);
        this.power = this.rarityTable.GetPowerByRarity(chosenRarity);
        this.choicesList = GetRandomUpgrades(3);

        this.iconList[0].sprite = this.choicesList[0].icon;
        this.iconList[1].sprite = this.choicesList[1].icon;
        this.iconList[2].sprite = this.choicesList[2].icon;

        this.namesList[0].text = this.choicesList[0].name;
        this.namesList[0].color = color;
        this.namesList[1].text = this.choicesList[1].name;
        this.namesList[1].color = color;
        this.namesList[2].text = this.choicesList[2].name;
        this.namesList[2].color = color;

        this.valuesList[0].text = (this.choicesList[0].value * power).ToString();
        this.valuesList[0].color = color;
        this.valuesList[1].text = (this.choicesList[1].value * power).ToString();
        this.valuesList[1].color = color;
        this.valuesList[2].text = (this.choicesList[2].value * power).ToString();
        this.valuesList[2].color = color;
    }

    public void ApplyUpgrade(int index)
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        
        UpgradeData chosen = this.choicesList[index];
        float finalValue = chosen.value * this.power;
        this.yasuoStats.ApplyUpgrade(chosen.type, finalValue);

        this.levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private List<UpgradeData> GetRandomUpgrades(int count)
    {
        List<UpgradeData> copy = new List<UpgradeData>(this.upgradeTable.upgrades);
        List<UpgradeData> result = new List<UpgradeData>();

        for (int i = 0; i < count && copy.Count > 0; i++)
        {
            int index = Random.Range(0, copy.Count);
            result.Add(copy[index]);
            copy.RemoveAt(index);
        }

        return result;
    }

    void LoadCoreData()
    {
        this.levelUpPanel.SetActive(true);

        foreach (GameObject coreItem in this.listCores)
        {
            TMP_Text coreName = coreItem.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text coreValue = coreItem.transform.Find("Value").GetComponent<TMP_Text>();
            Image coreIcon = coreItem.transform.Find("Icon").GetComponent<Image>();
            this.namesList.Add(coreName);
            this.valuesList.Add(coreValue);
            this.iconList.Add(coreIcon);
        }

        this.levelUpPanel.SetActive(false);
    }
}