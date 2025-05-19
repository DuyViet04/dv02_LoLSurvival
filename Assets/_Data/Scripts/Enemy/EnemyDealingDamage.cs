using System;
using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;

    private void Awake()
    {
        this.stats = SOManager.Instance.GetStatsByType(this.transform.parent.name);
    }

    private void FixedUpdate()
    {
        this.damage = this.stats.damage;
    }
}