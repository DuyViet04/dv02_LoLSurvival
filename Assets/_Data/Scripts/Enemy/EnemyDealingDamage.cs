using System;
using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MeleeEnemyStats baseMeleeEnemyStats;
    private MeleeEnemyStats meleeEnemyStats;

    private void Awake()
    {
        this.meleeEnemyStats = Instantiate(this.baseMeleeEnemyStats);
    }

    private void Start()
    {
        this.damage = this.meleeEnemyStats.damage;
    }
}