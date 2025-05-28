using UnityEngine;

[CreateAssetMenu(fileName = "CannonEnemyStats", menuName = "Stats/Enemy/CannonEnemy")]
public class CannonEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.CannonEnemy;
        this.health = 83.5f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 37.5f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.attackSpeed = 1f;
        this.moveSpeed = 1.5f;
        this.armor = 1f;
        this.magicResistance = 1f;
        this.expValue = 95f;
        this.goldValue = 60f;
        this.csValue = 1f;
        this.spawnDelay = 30f;
        this.spawnCount = 1f;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.CannonEnemy;
        this.health = 83.5f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 37.5f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.attackSpeed = 1f;
        this.moveSpeed = 1.5f;
        this.armor = 1f;
        this.magicResistance = 1f;
        this.expValue = 95f;
        this.goldValue = 60f;
        this.csValue = 1f;
        this.spawnDelay = 30f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        CannonEnemyStats stats = CreateInstance<CannonEnemyStats>();
        stats.ResetStats();
        return stats;
    }
}