using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/Enemy/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.MeleeEnemy;
        this.health = 46.5f;
        this.damage = 11f;
        this.moveSpeed = 1.5f;
        this.armor = 20f;
        this.magicResistance = 1f;
        this.expValue = 61.75f;
        this.goldValue = 21f;
        this.csValue = 1f;
        this.spawnDelay = 3f;
        this.spawnCount = 3f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        MeleeEnemyStats newStats = new MeleeEnemyStats();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.MeleeEnemy;
        this.health = 46.5f;
        this.damage = 11f;
        this.moveSpeed = 1.5f;
        this.armor = 20f;
        this.magicResistance = 1f;
        this.expValue = 61.75f;
        this.goldValue = 21f;
        this.csValue = 1f;
        this.spawnDelay = 3f;
        this.spawnCount = 3f;
    }
}