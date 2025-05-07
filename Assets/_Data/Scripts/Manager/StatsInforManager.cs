using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsInforManager : MonoBehaviour
{
    private static StatsInforManager instance;

    public static StatsInforManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private Image mainStats;
    [SerializeField] private Image secondStats;
    [SerializeField] private GameObject mainStatsPanel;
    [SerializeField] private GameObject secondStatsPanel;
    [SerializeField] public List<TMP_Text> mainData;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one StatsInforManager in scene!");
        instance = this;
        
        this.LoadMainData();
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

    void LoadMainData()
    {
        Transform mainDataContainer = this.mainStatsPanel.transform.Find("StatsData");

        foreach (Transform obj in mainDataContainer)
        {
            TMP_Text text = obj.GetComponent<TMP_Text>();
            mainData.Add(text);
        }
    }
}