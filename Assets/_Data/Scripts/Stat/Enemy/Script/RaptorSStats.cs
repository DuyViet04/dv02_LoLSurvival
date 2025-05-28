using UnityEngine;

[CreateAssetMenu(fileName = "RaptorSStats", menuName = "Stats/Enemy/RaptorS")]
public class RaptorSStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RaptorS;
        this.health = 50;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 7f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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
        RaptorSStats newStats = CreateInstance<RaptorSStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.RaptorS;
        this.health = 50;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 7f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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