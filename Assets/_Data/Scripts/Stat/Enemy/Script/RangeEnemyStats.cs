using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeEnemyStats", menuName = "Stats/Enemy/RangeEnemy")]
public class RangeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.RangeEnemy;
        this.health = 28.4f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 42f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.attackSpeed = 0.25f;
        this.moveSpeed = 1.5f;
        this.armor = 1f;
        this.magicResistance = 1f;
        this.expValue = 30.4f;
        this.goldValue = 14f;
        this.csValue = 1f;
        this.spawnDelay = 6f;
        this.spawnCount = 3f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        RangeEnemyStats newStats = CreateInstance<RangeEnemyStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.RangeEnemy;
        this.health = 28.4f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = 42f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.attackSpeed = 0.25f;
        this.moveSpeed = 1.5f;
        this.armor = 1f;
        this.magicResistance = 1f;
        this.expValue = 30.4f;
        this.goldValue = 14f;
        this.csValue = 1f;
        this.spawnDelay = 6f;
        this.spawnCount = 3f;
    }
}