using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
    }

    //Reset giá trị của các SO về mặc định
    protected override void ResetValues()
    {
        base.ResetValues();
        this.ResetStats();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids =
            AssetDatabase.FindAssets("t:YasuoStats", new string[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
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