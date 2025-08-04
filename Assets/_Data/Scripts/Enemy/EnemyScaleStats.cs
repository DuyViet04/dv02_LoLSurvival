using UnityEngine;

public class EnemyScaleStats : VyesBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private LevelUp levelUp;
    [SerializeField] private float rate = 0.1f;
    public MainEnemyStats baseStats;

    private void FixedUpdate()
    {
        float currentLevel = this.levelUp.GetCurrentLevel();
        this.ScaleByLevel(currentLevel, this.stats, this.baseStats, this.rate);
    }

    // Phương thức này sẽ scale stats của Enemy dựa trên level
    void ScaleByLevel(float level, MainEnemyStats stat, MainEnemyStats baseStat, float rate)
    {
        stat.health = baseStat.health * (1 + level * rate);
        stat.attackData.baseDamage = baseStat.attackData.baseDamage * (1 + level * rate);
        stat.moveSpeed = baseStat.moveSpeed * (1 + level * rate / 10);
        stat.armor = baseStat.armor * (1 + level * rate);
        stat.magicResistance = baseStat.magicResistance * (1 + level * rate);
        stat.expValue = baseStat.expValue * (1 + level * rate);
        stat.goldValue = baseStat.goldValue * (1 + level * rate);
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        this.baseStats = this.stats.GetBaseStats();
    }
}