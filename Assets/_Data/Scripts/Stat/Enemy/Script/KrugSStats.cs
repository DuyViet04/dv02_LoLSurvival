using UnityEngine;

[CreateAssetMenu(fileName = "KrugSStats", menuName = "Stats/Enemy/KrugS")]
public class KrugSStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.KrugS;
        this.health = 6f;
        this.damage = 13f;
        this.moveSpeed = 4f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 16f;
        this.goldValue = 14f;
        this.csValue = 0.25f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 2f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        KrugSStats newStats = CreateInstance<KrugSStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.KrugS;
        this.health = 6f;
        this.damage = 13f;
        this.moveSpeed = 4f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 16f;
        this.goldValue = 14f;
        this.csValue = 0.25f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 2f;
    }
}