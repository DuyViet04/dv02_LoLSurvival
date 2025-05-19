using System;
using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private EnemyScaleStats scaleStats;
    private MeleeEnemyStats meleeEnemyStats;

    private void Update()
    {
        this.meleeEnemyStats = this.scaleStats.GetStats();
        this.damage = this.meleeEnemyStats.damage;
    }
}