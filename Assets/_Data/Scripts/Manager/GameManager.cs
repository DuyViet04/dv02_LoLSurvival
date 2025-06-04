using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : VyesPersistentSingleton<GameManager>
{
    [SerializeField] private YasuoStats yasuoStats;
    private int csCount;
    private List<Sprite> itemSprites;
    private List<TMP_Text> mainStatsData;
    private List<TMP_Text> secondStatsData;

    protected override void Awake()
    {
        base.Awake();
        this.mainStatsData = new List<TMP_Text>();
    }

    public int CSCount
    {
        get => this.csCount;
        set => this.csCount = value;
    }

    public List<Sprite> ItemSprites
    {
        get => this.itemSprites;
        set => this.itemSprites = value;
    }

    public List<TMP_Text> MainStatsData
    {
        get => this.mainStatsData;
        set => this.mainStatsData = value;
    }

    public List<TMP_Text> SecondStatsData
    {
        get => this.secondStatsData;
        set => this.secondStatsData = value;
    }


    //Reset giá trị của các SO về mặc định

    protected override void ResetValues()
    {
        base.ResetValues();
        this.ResetStats();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        this.yasuoStats = SOManager.Instance.GetYasuoStats();
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void ResetStats()
    {
        this.yasuoStats.ResetStats();

        List<MainEnemyStats> list = SOManager.Instance.GetEnemyStatsList();
        foreach (MainEnemyStats item in list)
        {
            item.ResetStats();
        }
    }
}