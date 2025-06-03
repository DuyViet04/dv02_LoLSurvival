using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsEndgameDisplay : VyesBehaviour
{
    [SerializeField] private Image mainStats;
    [SerializeField] private Image secondStats;
    [SerializeField] public GameObject mainStatsPanel;
    [SerializeField] private GameObject secondStatsPanel;
    private List<TMP_Text> mainStatsData;
    private List<TMP_Text> secondStatsData;

    protected override void Awake()
    {
        base.Awake();
        this.mainStatsData = new List<TMP_Text>();
        this.secondStatsData = new List<TMP_Text>();

        this.LoadMainData();
        this.LoadSecondData();
    }

    private void Start()
    {
        this.UpdateMainData();
    }

    public void ShowMainStats()
    {
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
        this.mainStatsPanel.SetActive(false);
        Color mainColor = this.mainStats.color;
        mainColor.a = Mathf.Clamp01(200f / 255f);
        this.mainStats.color = mainColor;

        this.secondStatsPanel.SetActive(true);
        Color secondColor = this.secondStats.color;
        secondColor.a = Mathf.Clamp01(0f / 255f);
        this.secondStats.color = secondColor;
    }

    void UpdateMainData()
    {
        List<TMP_Text> mainStats = GameManager.Instance.MainStatsData;
        for (int i = 0; i < mainStats.Count; i++)
        {
            if (i < this.mainStatsData.Count)
            {
                this.mainStatsData[i].text = mainStats[i].text;
            }
        }
    }
    
    void UpdateSecondData()
    {
        List<TMP_Text> secondStats = GameManager.Instance.SecondStatsData;
        for (int i = 0; i < secondStats.Count; i++)
        {
            if (i < this.secondStatsData.Count)
            {
                this.secondStatsData[i].text = secondStats[i].text;
            }
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainStats();
        this.LoadSecondStats();
        this.LoadMainStatsPanel();
        this.LoadSecondStatsPanel();
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

    void LoadMainStats()
    {
        if (this.mainStats != null) return;
        this.mainStats = GameObject.Find("MainStatsTitle").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadMainStats", this.gameObject);
    }

    void LoadSecondStats()
    {
        if (this.secondStats != null) return;
        this.secondStats = GameObject.Find("SecondStatsTitle").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadSecondStats", this.gameObject);
    }

    void LoadMainStatsPanel()
    {
        if (this.mainStatsPanel != null) return;
        this.mainStatsPanel = GameObject.Find("MainStatsInfo");
        Debug.LogWarning(this.transform.name + ": LoadMainStatsPanel", this.gameObject);
    }

    void LoadSecondStatsPanel()
    {
        if (this.secondStatsPanel != null) return;
        this.secondStatsPanel = GameObject.Find("SecondStatsInfo");
        Debug.LogWarning(this.transform.name + ": LoadSecondStatsPanel", this.gameObject);
    }
}