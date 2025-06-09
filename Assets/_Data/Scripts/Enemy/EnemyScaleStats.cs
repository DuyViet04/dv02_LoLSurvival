using UnityEngine;

public class EnemyScaleStats : VyesBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private LevelUp levelUp;
    public MainEnemyStats baseStats;

    private void FixedUpdate()
    {
        float currentLevel = this.levelUp.GetCurrentLevel();
        this.ScaleByLevel(currentLevel, this.stats, this.baseStats);
    }

    void ScaleByLevel(float level, MainEnemyStats stat, MainEnemyStats baseStat)
    {
        stat.health = baseStat.health * (1 + level * 0.1f);
        stat.attackData.baseDamage = baseStat.attackData.baseDamage * (1 + level * 0.1f);
        stat.moveSpeed = baseStat.moveSpeed * (1 + level * 0.1f);
        stat.armor = baseStat.armor * (1 + level * 0.1f);
        stat.magicResistance = baseStat.magicResistance * (1 + level * 0.1f);
        stat.expValue = baseStat.expValue * (1 + level * 0.1f);
        stat.goldValue = baseStat.goldValue * (1 + level * 0.1f);
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
        this.stats = SOManager.Instance.GetEnemyStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadLevelUp()
    {
        if (this.levelUp != null) return;
        this.levelUp = GameObject.FindObjectOfType<LevelUp>();
        Debug.LogWarning(this.transform.name + ": LoadLevelUp", this.gameObject);
    }
}