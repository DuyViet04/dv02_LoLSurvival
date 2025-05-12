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

        float lifeStealValue = this.damageDeal * this.stats.lifeSteal * (1 + this.stats.healingPower / 100);
        takingDamage.LifeSteal(lifeStealValue);

        float omnivampValue = this.stats.omnivamp * this.stats.omnivamp * (1 + this.stats.healingPower / 100);
        takingDamage.Omnivamp(omnivampValue);
    }
}