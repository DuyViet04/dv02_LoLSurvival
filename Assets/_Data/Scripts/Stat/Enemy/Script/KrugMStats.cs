using UnityEngine;

[CreateAssetMenu(fileName = "KrugMStats", menuName = "Stats/Enemy/KrugM")]
public class KrugMStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.KrugM;
        this.health = 65f;
        this.damage = 20f;
        this.moveSpeed = 3.5f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 10f;
        this.goldValue = 10f;
        this.csValue = 0.5f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 2f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        KrugMStats newStats = CreateInstance<KrugMStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.KrugM;
        this.health = 65f;
        this.damage = 20f;
        this.moveSpeed = 3.5f;
        this.armor = 20f;
        this.magicResistance = 20f;
        this.expValue = 10f;
        this.goldValue = 10f;
        this.csValue = 0.5f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 2f;
    }
}