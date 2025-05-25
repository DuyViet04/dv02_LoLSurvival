using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;

    private void FixedUpdate()
    {
        this.damage = this.stats.damage;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
    }

    void LoadStats()
    {
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }
}