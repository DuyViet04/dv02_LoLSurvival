using UnityEngine;

[CreateAssetMenu(fileName = "MurkWolfLStats", menuName = "Stats/Enemy/MurkWolfL")]
public class MurkWolfLStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.MurkWolfL;
        this.health = 160f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 30f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 5.25f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 50f;
        this.goldValue = 50f;
        this.csValue = 2f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        MurkWolfLStats newStats = CreateInstance<MurkWolfLStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.MurkWolfL;
        this.health = 160f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 30f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 5.25f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 50f;
        this.goldValue = 50f;
        this.csValue = 2f;
        this.spawnDelay = 3 * 60f;
        this.spawnCount = 1f;
    }
}