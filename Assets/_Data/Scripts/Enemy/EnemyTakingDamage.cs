using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private MeleeEnemyStats stats;
    private MeleeEnemyStats baseStats;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;

        this.baseStats = stats.Clone();
    }

    private void FixedUpdate()
    {
        this.armor = this.stats.armor;
    }

    public override void Despawn()
    {
        this.CreateExp();
        this.IncreaseStats();
        this.ResetStats();
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }

    void CreateExp()
    {
        Transform exp = ExpSpawner.Instance.Spawn("Exp", this.transform.parent.position, Quaternion.identity);
        exp.GetComponentInChildren<ItemBehaviour>().SetExpValue(this.stats.expValue);
    }

    void IncreaseStats()
    {
        this.stats.health += this.baseStats.health / 100;
        this.stats.armor += this.baseStats.armor / 100;
        this.stats.expValue += this.baseStats.expValue / 100;
        this.stats.damage += this.baseStats.damage / 100;
        this.stats.moveSpeed += this.baseStats.moveSpeed / 100;
    }

    void ResetStats()
    {
        this.currentHp = this.stats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform);
        }
    }
}