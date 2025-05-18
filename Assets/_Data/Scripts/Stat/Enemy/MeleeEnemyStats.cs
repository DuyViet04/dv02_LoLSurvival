using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/Enemy/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 46.5f;
        this.damage = 80;
        this.moveSpeed = 1.5f;
        this.armor = 20;
        this.expValue = 61.75f;
        this.goldValue = 21f;
    }
}