using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/Enemy/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.MeleeEnemy;
        this.health = 46.5f;
        this.damage = 80;
        this.moveSpeed = 1.5f;
        this.armor = 20;
        this.expValue = 61.75f;
        this.goldValue = 2.1f;
        this.spawnDelay = 3f;
        this.spawnCount = 3;
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
        this.damage = 80;
        this.moveSpeed = 1.5f;
        this.armor = 20;
        this.expValue = 61.75f;
        this.goldValue = 2.1f;
        this.spawnDelay = 3f;
        this.spawnCount = 3;
    }
}