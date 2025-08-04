using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : VyesSingleton<StatsDisplay>
{
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private Image mainStats;
    [SerializeField] private Image secondStats;
    [SerializeField] public GameObject mainStatsPanel;
    [SerializeField] private GameObject secondStatsPanel;
    [SerializeField] private YasuoStats yasuoStats;
    private LevelUp levelUp;
    private List<TMP_Text> mainStatsData;
    private List<TMP_Text> secondStatsData;

    protected override void Awake()
    {
        base.Awake();
        this.levelUp = FindObjectOfType<LevelUp>();
        this.mainStatsData = new List<TMP_Text>();
        this.secondStatsData = new List<TMP_Text>();

        this.LoadMainData();
        this.LoadSecondData();
        this.secondStatsPanel.SetActive(false);
    }

    public void ShowMainStats()
    {
        AudioManager.Instance.PlaySFXClip("Click");

        this.mainStatsPanel.SetActive(true);
        Color mainColor = this.mainStats.color;
        mainColor.a = Mathf.Clamp01(0f / 255f);
        this.mainStats.color = mainColor;

        this.secondStatsPanel.SetActive(false);
        Color secondColor = this.secondStats.color;
        secondColor.a = Mathf.Clamp01(200f / 255f);
        this.secondStats.color = secondColor;
    }

    public void ShowSecondStats()
    {
        AudioManager.Instance.PlaySFXClip("Click");

        this.mainStatsPanel.SetActive(false);
        Color mainColor = this.mainStats.color;
        mainColor.a = Mathf.Clamp01(200f / 255f);
        this.mainStats.color = mainColor;

        this.secondStatsPanel.SetActive(true);
        Color secondColor = this.secondStats.color;
        secondColor.a = Mathf.Clamp01(0f / 255f);
        this.secondStats.color = secondColor;
    }

    public void UpdateMainData()
    {
        FieldInfo[] fieldInfo = this.GetYasuoStatFields();
        this.mainStatsData[0].text = this.levelUp.GetCurrentLevel().ToString();

        for (int i = 1; i < 16; i++)
        {
            this.mainStatsData[i].text = $"{fieldInfo[i].GetValue(this.yasuoStats):F1}";
        }
    }

    public void UpdateSecondData()
    {
        FieldInfo[] fieldInfo = this.GetYasuoStatFields();
        for (int i = 16; i < 18; i++)
        {
            this.secondStatsData[i - 16].text = $"{fieldInfo[i].GetValue(this.yasuoStats):F1}";
        }
    }

    public List<TMP_Text> GetLastMainData()
    {
        this.UpdateMainData();
        return this.mainStatsData;
    }

    public List<TMP_Text> GetLastSecondData()
    {
        this.UpdateSecondData();
        return this.secondStatsData;
    }

    //Refection
    FieldInfo[] GetYasuoStatFields()
    {
        return typeof(YasuoStats).GetFields(BindingFlags.Public | BindingFlags.Instance);
    }

    void LoadMainData()
    {
        Transform mainDataContainer = this.mainStatsPanel.transform.Find("StatsData");

        foreach (Transform obj in mainDataContainer)
        {
            TMP_Text text = obj.GetComponent<TMP_Text>();
            this.mainStatsData.Add(text);
        }
    }

    void LoadSecondData()
    {
        Transform secondDataContainer = this.secondStatsPanel.transform.Find("StatsData");

        foreach (Transform obj in secondDataContainer)
        {
            TMP_Text text = obj.GetComponent<TMP_Text>();
            this.secondStatsData.Add(text);
        }
    }
}