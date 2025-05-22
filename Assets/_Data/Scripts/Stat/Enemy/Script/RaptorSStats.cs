using UnityEngine;

[CreateAssetMenu(fileName = "RaptorSStats", menuName = "Stats/Enemy/RaptorS")]
public class RaptorSStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RaptorS;
        this.health = 50;
        this.damage = 7f;
        this.moveSpeed = 5.25f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 10f;
        this.goldValue = 8f;
        this.csValue = 0.4f;
        this.spawnDelay = 4 * 60f;
        this.spawnCount = 5f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        MeleeEnemyStats newStats = new MeleeEnemyStats();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.RaptorS;
        this.health = 50;
        this.damage = 7f;
        this.moveSpeed = 5.25f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 10f;
        this.goldValue = 8f;
        this.csValue = 0.4f;
        this.spawnDelay = 4 * 60f;
        this.spawnCount = 5f;
    }
}