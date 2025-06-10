using UnityEngine;

[CreateAssetMenu(fileName = "BossAatrox", menuName = "Stats/Boss/Aatrox")]
public class BossAatroxStats : MainBossStats
{
    private void Reset()
    {
        this.bossType = BossType.BossAatrox;
        this.characterName = "BossAatrox";
        this.health = 1300f;
        this.healthRegen = 6f;
        this.attackDamage = 120f;
        this.abilityPower = 0f;
        this.armor = 76f;
        this.magicResistance = 64f;
        this.moveSpeed = 3f;
        this.criticalChance = 0f;
        this.criticalDamage = 0f;
        this.armorPenetration = 0f;
        this.magicPenetration = 0f;
        this.lifeSteal = 0f;
        this.omnivamp = 0f;
        this.haste = 0f;
        this.healingPower = 0f;
    }
    public override void ResetStats()
    {
        this.bossType = BossType.BossAatrox;
        this.characterName = "BossAatrox";
        this.health = 1300f;
        this.healthRegen = 6f;
        this.attackDamage = 120f;
        this.abilityPower = 0f;
        this.armor = 76f;
        this.magicResistance = 64f;
        this.moveSpeed = 3f;
        this.criticalChance = 0f;
        this.criticalDamage = 0f;
        this.armorPenetration = 0f;
        this.magicPenetration = 0f;
        this.lifeSteal = 0f;
        this.omnivamp = 0f;
        this.haste = 0f;
        this.healingPower = 0f;
    }

    public override MainBossStats GetBaseStats()
    {
        BossAatroxStats newStats = CreateInstance<BossAatroxStats>();
        newStats.ResetStats();
        return newStats;
    }
}