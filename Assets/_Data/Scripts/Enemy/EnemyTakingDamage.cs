using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private MeleeEnemyStats stats;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log(currentHp);
    }

    public override void Despawn()
    {
        this.CreateExp();
        this.ResetStats();
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }

    void CreateExp()
    {
        ExpSpawner.Instance.Spawn("Exp", this.transform.parent.position, Quaternion.identity);
    }

    void ResetStats()
    {
        this.currentHp = this.maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform);
            Debug.Log("Enemy Taking Damage");
        }
    }
}