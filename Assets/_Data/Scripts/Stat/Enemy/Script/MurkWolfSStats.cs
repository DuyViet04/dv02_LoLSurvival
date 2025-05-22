using UnityEngine;

[CreateAssetMenu(fileName = "MurkWolfSStats", menuName = "Stats/Enemy/MurkWolfS")]
public class MurkWolfSStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.MurkWolfS;
        this.health = 63f;
        this.damage = 10f;
        this.moveSpeed = 5.25f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 15f;
        this.goldValue = 15f;
        this.csValue = 1f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 2f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        MeleeEnemyStats newStats = new MeleeEnemyStats();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.MurkWolfS;
        this.health = 63f;
        this.damage = 10f;
        this.moveSpeed = 5.25f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 15f;
        this.goldValue = 15f;
        this.csValue = 1f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 2f;
    }
}