using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MeleeEnemyStats stats;

    private void Start()
    {
        base.damage = this.stats.damage;
    }

    public override void DealDamage(TakingDamage takingDamage)
    {
        base.DealDamage(takingDamage);
    }
}