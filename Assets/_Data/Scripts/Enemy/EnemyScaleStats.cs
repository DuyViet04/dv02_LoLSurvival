using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScaleStats : MonoBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private TimeDisplay timeDisplay;
    private MainEnemyStats baseStats;

    private void Awake()
    {
        this.stats = SOManager.Instance.GetStatsByType(this.transform.parent.name);
        this.baseStats = this.stats.GetBaseStats();
    }

    private void FixedUpdate()
    {
        float time = this.timeDisplay.GetTime();
        this.ScaleByTime(time, this.stats, this.baseStats);
    }

    void ScaleByTime(float time, MainEnemyStats stat, MainEnemyStats baseStat)
    {
        stat.health = baseStat.health * (1f + time * 0.01f);
        stat.damage = baseStat.damage * (1f + time * 0.01f);
        stat.armor = baseStat.armor * (1f + time * 0.01f);
        stat.moveSpeed = baseStat.moveSpeed * (1f + time * 0.001f);
        stat.expValue = baseStat.expValue * (1f + time * 0.01f);
        stat.goldValue = baseStat.goldValue * (1f + time * 0.01f);
    }
}