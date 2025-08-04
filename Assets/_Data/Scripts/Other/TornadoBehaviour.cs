using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBehaviour : DealingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private float distance = 15f;
    private float currentDis = 0f;

    private void Update()
    {
        this.Move();
    }

    void Move()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * 12f);
        this.currentDis += (Vector3.down * Time.deltaTime * 12f).magnitude;
        if (this.currentDis >= this.distance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && (parent.CompareTag(nameof(TagEnum.Enemy)) || parent.CompareTag(nameof(TagEnum.Boss))))
        {
            this.attackDamage = this.yasuoStats.attackDamage;
            this.abilityPower = this.yasuoStats.abilityPower;
            this.armorPenetration = this.yasuoStats.armorPenetration;
            this.magicPenetration = this.yasuoStats.magicPenetration;
            this.criticalChance = this.yasuoStats.criticalChance;
            this.criticalDamage = this.yasuoStats.criticalDamage;
            this.lifeSteal = this.yasuoStats.lifeSteal;
            this.omnivamp = this.yasuoStats.omnivamp;
            this.healingPower = this.yasuoStats.healingPower;

            AttackData attackData = FindObjectOfType<Skill1Attack>().GetAttackData();
            this.DealDamage(parent.transform, attackData);
            this.Heal(FindObjectOfType<PlayerTakingDamage>());
        }
    }
}