using UnityEngine;

[CreateAssetMenu(fileName = "RaptorLStats", menuName = "Stats/Enemy/RaptorL")]
public class RaptorLStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RaptorL;
        this.health = 120f;
        this.damage = 17f;
        this.moveSpeed = 4.5f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 20f;
        this.goldValue = 30f;
        this.csValue = 2f;
        this.spawnDelay = 4 * 60f;
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
        this.type = EnemyType.RaptorL;
        this.health = 120f;
        this.damage = 17f;
        this.moveSpeed = 4.5f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 20f;
        this.goldValue = 30f;
        this.csValue = 2f;
        this.spawnDelay = 4 * 60f;
        this.spawnCount = 1f;
    }
}
