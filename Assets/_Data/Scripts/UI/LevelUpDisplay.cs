using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpDisplay : MonoBehaviour
{
    private static LevelUpDisplay instance;
    public static LevelUpDisplay Instance => instance;

    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private YasuoStats baseYasuoStats;
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;
    [SerializeField] private GameObject core;
    [SerializeField] private GameObject core1;
    [SerializeField] private GameObject core2;
    private YasuoStats yasuoStats;
    private RarityType chosenRarity;
    private int power;
    private List<GameObject> coresList;
    private List<TMP_Text> namesList;
    private List<TMP_Text> valuesList;
    private List<UpgradeData> choicesList;

    void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of LevelUpManager");
        instance = this;

        this.yasuoStats = Instantiate(this.baseYasuoStats);

        this.namesList = new List<TMP_Text>();
        this.valuesList = new List<TMP_Text>();
        this.coresList = new List<GameObject> { this.core, this.core1, this.core2 };
        this.LoadNamesAndValues();
    }

    public void ShowUpgradeChoices()
    {
        this.chosenRarity = this.rarityTable.GetRandomRarity();
        Color color = this.rarityTable.GetColorByRarity(chosenRarity);
        this.power = this.rarityTable.GetPowerByRarity(chosenRarity);
        this.choicesList = GetRandomUpgrades(3);

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

    void LoadNamesAndValues()
    {
        this.levelUpPanel.SetActive(true);

        foreach (GameObject coreItem in this.coresList)
        {
            TMP_Text coreName = coreItem.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text coreValue = coreItem.transform.Find("Value").GetComponent<TMP_Text>();
            this.namesList.Add(coreName);
            this.valuesList.Add(coreValue);
        }

        this.levelUpPanel.SetActive(false);
    }
}