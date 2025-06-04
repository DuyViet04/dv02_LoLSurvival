using System.Collections.Generic;
using UnityEngine;

public class SOManager : VyesPersistentSingleton<SOManager>
{
    [SerializeField] private List<MainEnemyStats> enemyStatsList;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.enemyStatsList.Clear();
        this.LoadEnemyStatsList();
        this.LoadYasuoStats();
        this.LoadYasuoSkill();
    }

    void LoadEnemyStatsList()
    {
        MainEnemyStats[] enemyList = Resources.LoadAll<MainEnemyStats>("Stat/Enemy");
        foreach (MainEnemyStats enemy in enemyList)
        {
            this.enemyStatsList.Add(enemy);
        }
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        this.yasuoStats = Resources.Load<YasuoStats>("Stat/Character/YasuoStats");
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadYasuoSkill()
    {
        if (this.yasuoSkill != null) return;
        this.yasuoSkill = Resources.Load<YasuoSkill>("Skill/YasuoSkill");
        Debug.LogWarning(this.transform.name + ": LoadYasuoSkill", this.gameObject);
    }

    public MainEnemyStats GetStatsByType(string type)
    {
        foreach (MainEnemyStats item in this.enemyStatsList)
        {
            string typeName = item.type.ToString();
            if (typeName == type) return item;
        }

        return null;
    }

    public List<MainEnemyStats> GetEnemyStatsList()
    {
        return this.enemyStatsList;
    }

    public YasuoStats GetYasuoStats()
    {
        return this.yasuoStats;
    }

    public YasuoSkill GetYasuoSkill()
    {
        return this.yasuoSkill;
    }
}