using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        this.lifeSteal = this.yasuoStats.lifeSteal;
        this.omnivamp = this.yasuoStats.omnivamp;
        this.healingPower = this.yasuoStats.healingPower;
    }

    protected override void DealDamage(TakingDamage takingDamage)
    {
        base.DealDamage(takingDamage);
        takingDamage.TakeDamage(this.damageDealt);
        this.Heal(this.player.GetComponentInChildren<PlayerTakingDamage>());
    }

    protected override float GetDamageDealt(TakingDamage takingDamage)
    {
        float dmgMulti = takingDamage.GetDamageMultiplier(this.yasuoStats.armorPenetration);
        float roll = Random.Range(0f, 100f);
        if (roll > this.yasuoStats.criticalChance)
        {
            this.damageDealt = this.yasuoStats.attackDamage * dmgMulti;
        }
        else
        {
            this.damageDealt = this.yasuoStats.attackDamage * this.yasuoStats.criticalDamage / 100 * dmgMulti;
        }

        return this.damageDealt;
    }
}