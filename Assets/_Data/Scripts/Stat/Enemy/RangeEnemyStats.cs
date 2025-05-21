using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeEnemyStats", menuName = "Stats/Enemy/RangeEnemy")]
public class RangeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RangeEnemy;
        this.health = 29.6f;
        this.damage = 120f;
        this.attackSpeed = 0.667f;
        this.moveSpeed = 1.5f;
        this.expValue = 30.4f;
        this.goldValue = 1.4f;
        this.spawnDelay = 6f;
        this.spawnCount = 3;
    }

    public override MainEnemyStats GetBaseStats()
    {
        RangeEnemyStats newStats = new RangeEnemyStats();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.RangeEnemy;
        this.health = 29.6f;
        this.damage = 120f;
        this.attackSpeed = 0.667f;
        this.moveSpeed = 1.5f;
        this.expValue = 30.4f;
        this.goldValue = 1.4f;
        this.spawnDelay = 10f;
        this.spawnCount = 3;
    }
}