using UnityEngine;

[CreateAssetMenu(fileName = "BlueStats", menuName = "Stats/Enemy/Blue")]
public class BlueStats : MainEnemyStats
{
    private void Reset()
    {
        this.type = EnemyType.Blue;
        this.health = 230f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 66f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 2.75f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 95f;
        this.goldValue = 90f;
        this.csValue = 4f;
        this.spawnDelay = 6 * 60f;
        this.spawnCount = 1f;
    }

    public override MainEnemyStats GetBaseStats()
    {
        BlueStats newStats = CreateInstance<BlueStats>();
        newStats.ResetStats();
        return newStats;
    }

    public override void ResetStats()
    {
        this.type = EnemyType.Blue;
        this.health = 230f;
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.MagicDamage,
            baseDamage = 66f,
            bonusAD = 0f,
            bonusAP = 0f,
            isCritical = false,
            cooldown = 0f
        };
        this.moveSpeed = 2.75f;
        this.armor = 42f;
        this.magicResistance = 42f;
        this.expValue = 95f;
        this.goldValue = 90f;
        this.csValue = 4f;
        this.spawnDelay = 6 * 60f;
        this.spawnCount = 1f;
    }
}