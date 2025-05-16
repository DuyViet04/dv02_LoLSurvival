using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MeleeEnemyStats stats;

    private void Start()
    {
        this.damage = this.stats.damage;
    }
}