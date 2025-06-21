using UnityEngine;

public class BossScaling : VyesBehaviour
{
    [SerializeField] private MainBossStats stats;
    [SerializeField] private LevelUp levelUp;
    public MainBossStats baseStats;

    protected override void Awake()
    {
        base.Awake();
        float currentLevel = this.levelUp.GetCurrentLevel();
        this.ScaleByLevel(currentLevel, this.stats, this.baseStats);
    }

    // Tính toán scale của Boss theo level người chơi
    void ScaleByLevel(float level, MainBossStats stat, MainBossStats baseStat)
    {
        stat.health = baseStat.health * (1 + level * 0.1f);
        stat.healthRegen = baseStat.healthRegen * (1 + level * 0.1f);
        stat.attackDamage = baseStat.attackDamage * (1 + level * 0.1f);
        stat.moveSpeed = baseStat.moveSpeed * (1 + level * 0.01f);
        stat.armor = baseStat.armor * (1 + level * 0.1f);
        stat.magicResistance = baseStat.magicResistance * (1 + level * 0.1f);
        stat.criticalChance = baseStat.criticalChance * (1 + level * 0.1f);
        stat.criticalDamage = baseStat.criticalDamage * (1 + level * 0.1f);
        stat.armorPenetration = baseStat.armorPenetration * (1 + level * 0.1f);
        stat.magicPenetration = baseStat.magicPenetration * (1 + level * 0.1f);
        stat.lifeSteal = baseStat.lifeSteal * (1 + level * 0.1f);
        stat.omnivamp = baseStat.omnivamp * (1 + level * 0.1f);
        stat.haste = baseStat.haste * (1 + level * 0.1f);
        stat.healingPower = baseStat.healingPower * (1 + level * 0.1f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadLevelUp();
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        this.baseStats = this.stats.GetBaseStats();
    }

    void LoadStats()
    {
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetBossStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadLevelUp()
    {
        if (this.levelUp != null) return;
        this.levelUp = GameObject.FindObjectOfType<LevelUp>();
        Debug.LogWarning(this.transform.name + ": LoadLevelUp", this.gameObject);
    }
}