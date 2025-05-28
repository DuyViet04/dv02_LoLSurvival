using UnityEngine;

[CreateAssetMenu(fileName = "KrugSStats", menuName = "Stats/Enemy/KrugS")]
public class KrugSStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.KrugS;
        this.health = 6f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 13f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 13f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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