using UnityEngine;

[CreateAssetMenu(fileName = "KrugLStats", menuName = "Stats/Enemy/KrugL")]
public class KrugLStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.KrugL;
        this.health = 135f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 57f,
            bonusAD = 0,
            bonusAP = 0,
            cooldown = 0,
            isCritical = false
        };
        this.moveSpeed = 2.5f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 15f;
        this.goldValue = 15f;
        this.csValue = 2f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        KrugLStats newStats = CreateInstance<KrugLStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.KrugL;
        this.health = 135f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 57f,
            bonusAD = 0,
            bonusAP = 0,
            cooldown = 0,
            isCritical = false
        };
        this.moveSpeed = 2.5f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 15f;
        this.goldValue = 15f;
        this.csValue = 2f;
        this.spawnDelay = 5 * 60f;
        this.spawnCount = 1f;
    }
}