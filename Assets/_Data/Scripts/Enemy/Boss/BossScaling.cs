using UnityEngine;

public class BossScaling : VyesBehaviour
{
    [SerializeField] private MainBossStats stats;
    [SerializeField] private LevelUp levelUp;
    [SerializeField] private float rate = 0.1f;
    public MainBossStats baseStats;

    protected override void Awake()
    {
        base.Awake();
        float currentLevel = this.levelUp.GetCurrentLevel();
        this.ScaleByLevel(currentLevel, this.stats, this.baseStats, this.rate);
    }

    // Tính toán scale của Boss theo level người chơi
    void ScaleByLevel(float level, MainBossStats stat, MainBossStats baseStat, float rate)
    {
        stat.health = baseStat.health * (1 + level * rate);
        stat.healthRegen = baseStat.healthRegen * (1 + level * rate);
        stat.attackDamage = baseStat.attackDamage * (1 + level * rate);
        stat.moveSpeed = baseStat.moveSpeed * (1 + level * rate / 10);
        stat.armor = baseStat.armor * (1 + level * rate);
        stat.magicResistance = baseStat.magicResistance * (1 + level * rate);
        stat.criticalChance = baseStat.criticalChance * (1 + level * rate);
        stat.criticalDamage = baseStat.criticalDamage * (1 + level * rate);
        stat.armorPenetration = baseStat.armorPenetration * (1 + level * rate);
        stat.magicPenetration = baseStat.magicPenetration * (1 + level * rate);
        stat.lifeSteal = baseStat.lifeSteal * (1 + level * rate);
        stat.omnivamp = baseStat.omnivamp * (1 + level * rate);
        stat.haste = baseStat.haste * (1 + level * rate);
        stat.healingPower = baseStat.healingPower * (1 + level * rate);
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        this.baseStats = this.stats.GetBaseStats();
    }
}