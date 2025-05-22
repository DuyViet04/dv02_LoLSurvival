using UnityEngine;

[CreateAssetMenu(fileName = "MurkWolfLStats", menuName = "Stats/Enemy/MurkWolfL")]
public class MurkWolfLStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.MurkWolfL;
        this.health = 160f;
        this.damage = 30f;
        this.moveSpeed = 5.25f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 50f;
        this.goldValue = 50f;
        this.csValue = 2f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        MeleeEnemyStats newStats = new MeleeEnemyStats();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.MurkWolfL;
        this.health = 160f;
        this.damage = 30f;
        this.moveSpeed = 5.25f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 50f;
        this.goldValue = 50f;
        this.csValue = 2f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 1f;
    }
}