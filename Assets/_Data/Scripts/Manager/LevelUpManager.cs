using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelUpManager : MonoBehaviour
{
    private static LevelUpManager instance;

    public static LevelUpManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text data1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text data2;
    [SerializeField] private TMP_Text text3;
    [SerializeField] private TMP_Text data3;
    private List<UpgradeData> choicesList;
    private RarityType chosenRarity;
    private int power;

    void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of LevelUpManager");
        instance = this;
    }

    private void Start()
    {
        this.yasuoStats.ResetStats();
    }

    public void ShowUpgradeChoices()
    {
        this.chosenRarity = this.rarityTable.GetRandomRarity();
        Color color = this.rarityTable.GetColorByRarity(chosenRarity);
        this.power = this.rarityTable.GetPowerByRarity(chosenRarity);
        this.choicesList = GetRamdomUpgrades(3);

        this.text1.text = this.choicesList[0].name;
        this.text1.color = color;
        this.text2.text = this.choicesList[1].name;
        this.text2.color = color;
        this.text3.text = this.choicesList[2].name;
        this.text3.color = color;
        this.data1.text = (this.choicesList[0].value * power).ToString();
        this.data1.color = color;
        this.data2.text = (this.choicesList[1].value * power).ToString();
        this.data2.color = color;
        this.data3.text = (this.choicesList[2].value * power).ToString();
        this.data3.color = color;
    }

    public void ApplyUpgrade(int index)
    {
        UpgradeData chosen = this.choicesList[index];
        float finalValue = chosen.value * this.power;
        this.yasuoStats.ApplyUpgrade(chosen.type, finalValue);

        this.levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private List<UpgradeData> GetRamdomUpgrades(int count)
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
}