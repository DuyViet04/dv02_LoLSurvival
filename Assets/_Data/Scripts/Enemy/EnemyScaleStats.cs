using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScaleStats : MonoBehaviour
{
    [SerializeField] private MeleeEnemyStats baseMeleeEnemyStats;
    [SerializeField] private TimeDisplay timeDisplay;
    private MeleeEnemyStats meleeEnemyStats;

    private void Awake()
    {
        this.meleeEnemyStats = Instantiate(this.baseMeleeEnemyStats);
    }

    private void FixedUpdate()
    {
        float time = this.timeDisplay.GetTime();
        this.ScaleByTime(time, this.meleeEnemyStats, this.baseMeleeEnemyStats);
    }

    void ScaleByTime(float time, MeleeEnemyStats stat, MeleeEnemyStats baseStat)
    {
        stat.health = baseStat.health * (1f + time * 0.01f);
        stat.damage = baseStat.damage * (1f + time * 0.01f);
        stat.armor = baseStat.armor * (1f + time * 0.01f);
        stat.moveSpeed = baseStat.moveSpeed * (1f + time * 0.01f);
        stat.expValue = baseStat.expValue * (1f + time * 0.01f);
        stat.goldValue = baseStat.goldValue * (1f + time * 0.01f);
    }

    public MeleeEnemyStats GetStats()
    {
        return this.meleeEnemyStats;
    }
}