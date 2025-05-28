using UnityEngine;

[CreateAssetMenu(fileName = "RaptorLStats", menuName = "Stats/Enemy/RaptorL")]
public class RaptorLStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RaptorL;
        this.health = 120f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 17f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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
        RaptorLStats newStats = CreateInstance<RaptorLStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.RaptorL;
        this.health = 120f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 17f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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
