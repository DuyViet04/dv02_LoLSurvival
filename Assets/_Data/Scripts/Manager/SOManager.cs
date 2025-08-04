using System.Collections.Generic;
using UnityEngine;

public class SOManager : VyesPersistentSingleton<SOManager>
{
    [SerializeField] private List<MainEnemyStats> enemyStatsList;
    [SerializeField] private List<MainBossStats> bossStatsList;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;

    public MainEnemyStats GetEnemyStatsByType(string type)
    {
        foreach (MainEnemyStats item in this.enemyStatsList)
        {
            string typeName = item.type.ToString();
            if (typeName == type) return item;
        }

        return null;
    }

    public MainBossStats GetBossStatsByType(string type)
    {
        foreach (var item in this.bossStatsList)
        {
            string typeName = item.bossType.ToString();
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