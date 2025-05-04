using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats stats;

    private void Start()
    {
        base.damage = this.stats.attackDamage;
    }

    public override void DealDamage(TakingDamage takingDamage)
    {
        base.DealDamage(takingDamage);
    }
}
