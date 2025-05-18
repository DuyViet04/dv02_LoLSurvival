using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats baseYasuoStats;
    private YasuoStats yasuoStats;
    private float damageDeal;

    private void Awake()
    {
        this.yasuoStats = Instantiate(this.baseYasuoStats);
    }

    protected override void DealDamage(TakingDamage takingDamage)
    {
        float roll = Random.Range(0f, 100f);
        if (roll > this.yasuoStats.criticalChance)
        {
            this.damageDeal = this.yasuoStats.attackDamage;
        }
        else
        {
            this.damageDeal = this.yasuoStats.attackDamage * this.yasuoStats.criticalDamage / 100;
        }

        takingDamage.TakeDamage(this.damageDeal, this.yasuoStats.armorPenetration);

        this.Heal(this.transform.root.GetComponentInChildren<PlayerTakingDamage>(), this.damageDeal,
            this.yasuoStats.lifeSteal, this.yasuoStats.omnivamp, this.yasuoStats.healingPower);
    }
}