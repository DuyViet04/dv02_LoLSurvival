using UnityEngine;

[CreateAssetMenu(fileName = "SuperEnemyStats", menuName = "Stats/Enemy/SuperEnemy")]
public class SuperEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.SuperEnemy;
        this.health = 160f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 215f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 1.5f;
        this.armor = 100f;
        this.magicResistance = -30f;
        this.expValue = 95f;
        this.goldValue = 60f;
        this.csValue = 1f;
        this.spawnDelay = 60f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        SuperEnemyStats newStats = CreateInstance<SuperEnemyStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.SuperEnemy;
        this.health = 160f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 215f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 1.5f;
        this.armor = 100f;
        this.magicResistance = -30f;
        this.expValue = 95f;
        this.goldValue = 60f;
        this.csValue = 1f;
        this.spawnDelay = 60f;
        this.spawnCount = 1f;
    }
}