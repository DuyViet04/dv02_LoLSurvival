using UnityEngine;

[CreateAssetMenu(fileName = "GrompStats", menuName = "Stats/Enemy/Gromp")]
public class GrompStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.Gromp;
        this.health = 205f;
        this.damage = 70f;
        this.moveSpeed = 3.3f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 120f;
        this.goldValue = 80f;
        this.csValue = 4f;
        this.spawnDelay = 2 * 60f;
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
        this.type = EnemyType.Gromp;
        this.health = 205f;
        this.damage = 70f;
        this.moveSpeed = 3.3f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 120f;
        this.goldValue = 80f;
        this.csValue = 4f;
        this.spawnDelay = 2 * 60f;
        this.spawnCount = 1f;
    }
}