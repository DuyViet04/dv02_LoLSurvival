using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LevelUpDisplay : VyesSingleton<LevelUpDisplay>
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;
    [SerializeField] private List<GameObject> listCores;
    private RarityType chosenRarity;
    private int power;
    private List<TMP_Text> namesList;
    private List<TMP_Text> valuesList;
    private List<UpgradeData> choicesList;

    protected override void Awake()
    {
        base.Awake();
        this.namesList = new List<TMP_Text>();
        this.valuesList = new List<TMP_Text>();
        this.LoadNamesAndValues();
        this.LoadComponents();
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

        foreach (GameObject coreItem in this.listCores)
        {
            TMP_Text coreName = coreItem.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text coreValue = coreItem.transform.Find("Value").GetComponent<TMP_Text>();
            this.namesList.Add(coreName);
            this.valuesList.Add(coreValue);
        }

        this.levelUpPanel.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelUpPanel();
        this.LoadYasuoStats();
        this.LoadRarityTable();
        this.LoadUpgradeTable();
        this.LoadListCores();
    }

    private void LoadListCores()
    {
        this.listCores = new List<GameObject>();
        foreach (Transform item in this.levelUpPanel.transform)
        {
            this.listCores.Add(item.gameObject);
        }

        Debug.LogWarning(this.transform.name + ": LoadListCores", this.gameObject);
    }

    void LoadLevelUpPanel()
    {
        if (this.levelUpPanel != null) return;
        this.levelUpPanel = this.transform.Find("LevelUpPanel").gameObject;
        Debug.LogWarning(this.transform.name + ": LoadLevelUpPanel", this.gameObject);
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadRarityTable()
    {
        if (this.rarityTable != null) return;
        string[] guids = AssetDatabase.FindAssets("t:RarityTable", new[] { "Assets/_Data/Scripts/Stat" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.rarityTable = AssetDatabase.LoadAssetAtPath<RarityTable>(path);
        Debug.LogWarning(this.transform.name + ": LoadRarityTable", this.gameObject);
    }

    void LoadUpgradeTable()
    {
        if (this.upgradeTable != null) return;
        string[] guids = AssetDatabase.FindAssets("t:UpgradeTable", new[] { "Assets/_Data/Scripts/Stat" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.upgradeTable = AssetDatabase.LoadAssetAtPath<UpgradeTable>(path);
        Debug.LogWarning(this.transform.name + ": LoadUpgradeTable", this.gameObject);
    }
}