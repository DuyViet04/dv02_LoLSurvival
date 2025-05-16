using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 47.7f;
        this.damage = 12;
        this.moveSpeed = 1.5f;
        this.armor = 16;
        this.expValue = 61.75f;
    }

    public MeleeEnemyStats Clone()
    {
        return Instantiate(this);
    }

    public void ResetStats()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 47.7f;
        this.damage = 12;
        this.moveSpeed = 1.5f;
        this.armor = 16;
        this.expValue = 61.75f;
    }
}