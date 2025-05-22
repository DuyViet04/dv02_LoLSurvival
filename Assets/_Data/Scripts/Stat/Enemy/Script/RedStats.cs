using UnityEngine;

[CreateAssetMenu(fileName = "RedStats", menuName = "Stats/Enemy/Red")]
public class RedStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.Red;
        this.health = 230f;
        this.damage = 66f;
        this.moveSpeed = 2.75f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 95f;
        this.goldValue = 90f;
        this.csValue = 4f;
        this.spawnDelay = 7 * 60f;
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
        this.type = EnemyType.Red;
        this.health = 230f;
        this.damage = 66f;
        this.moveSpeed = 2.75f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 95f;
        this.goldValue = 90f;
        this.csValue = 4f;
        this.spawnDelay = 7 * 60f;
        this.spawnCount = 1f;
    }
}