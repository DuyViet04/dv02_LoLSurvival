using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats stats;
    private float damageDeal;

    public override void DealDamage(TakingDamage takingDamage)
    {
        float roll = Random.Range(0f, 100f);
        if (roll > this.stats.criticalChance)
        {
            this.damageDeal = this.stats.attackDamage;
        }
        else
        {
            this.damageDeal = this.stats.attackDamage * this.stats.criticalDamage / 100;
        }

        takingDamage.TakeDamage(this.damageDeal);
        Debug.Log("DamageDeal: " + damageDeal);
    }
}