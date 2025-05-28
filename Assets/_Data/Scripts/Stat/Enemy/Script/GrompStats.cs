using UnityEngine;

[CreateAssetMenu(fileName = "GrompStats", menuName = "Stats/Enemy/Gromp")]
public class GrompStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.Gromp;
        this.health = 205f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 70f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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
        GrompStats newStats = CreateInstance<GrompStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.Gromp;
        this.health = 205f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 70f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
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